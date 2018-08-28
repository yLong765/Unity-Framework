using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingletonMgr<ObjectPool>
{
	#region 生命周期函数

	void Awake()
	{
		_time = 0;
		InvokeRepeating("DelayRecycle", 1, 1);
	}

	#endregion

	#region 数据定义

	private int _time = 0;

	class ObjectData
	{
		public int recycleTime;
		public List<Component> instances;
	}
	Dictionary<Component, ObjectData> unusedObjects = new Dictionary<Component, ObjectData>();
	Dictionary<Component, Component> inUseObjects = new Dictionary<Component, Component>();
	Dictionary<Component, int> recycleObjects = new Dictionary<Component, int>();

	#endregion

	#region 初始化/反初始化

	public static void InitPool<T>(T prefab, int time, int count = 0) where T : Component
	{
		if (Instance == null)
			Debug.Log (";;;");
		if (Instance.unusedObjects.ContainsKey(prefab))
		{
			Debug.LogError("已初始化过 初始化数量为：" + Instance.unusedObjects[prefab].instances.Count);
		}
		else
		{
			ObjectData data = new ObjectData() { recycleTime = time, instances = new List<Component>() };
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					var obj = Instantiate(prefab);
					obj.transform.SetParent(Instance.transform);
					obj.gameObject.SetActive(false);
					data.instances.Add(obj);
				}
			}
			Instance.unusedObjects.Add(prefab, data);
		}
	}

	public static void InitPool(GameObject prefab, int time, int count)
	{
		ObjectPool.InitPool(prefab.transform, time, count);
	}

	public static void ClearPoolForObject<T>(T prefab) where T : Component
	{
		if (Instance.unusedObjects.ContainsKey(prefab))
		{
			for (int i = 0; i < Instance.unusedObjects[prefab].instances.Count; i++)
			{
				Destroy(Instance.unusedObjects[prefab].instances[i].gameObject);
			}
			Instance.unusedObjects[prefab].instances.Clear();
		}
	}

	public static void ClearAllPool()
	{
		RecycleAll();

		foreach (var item in Instance.unusedObjects)
		{
			if (item.Key != null && item.Value != null)
			{
				ClearPoolForObject(item.Key);
			}
		}
	}

	#endregion

	#region 创建Component

	public static T Spawn<T>(T prefab, Transform parent, Vector3 position, Quaternion rotation) where T : Component
	{
		T obj = null;

		if (Instance.unusedObjects.ContainsKey(prefab))
		{
			var list = Instance.unusedObjects[prefab].instances;
			while (obj == null && list.Count > 0)
			{
				obj = list[0] as T;
				list.RemoveAt(0);
			}
		}

		if (obj == null)
		{
			obj = Instantiate(prefab) as T;
		}

		if (obj != null)
		{
			obj.transform.SetParent(parent);
			obj.transform.localPosition = position;
			obj.transform.localRotation = rotation;
			obj.gameObject.SetActive(true);
			Instance.inUseObjects.Add(obj, prefab);

			if (Instance.unusedObjects[prefab].recycleTime > 0)
			{
				Instance.recycleObjects.Add(obj, Instance.unusedObjects[prefab].recycleTime + Instance._time);
			}
		}

		return obj;
	}

	public static T Spawn<T>(T prefab, Transform parent, Vector3 position) where T : Component
	{
		return Spawn(prefab, parent, position, Quaternion.identity);
	}

	public static T Spawn<T>(T prefab, Vector3 position) where T : Component
	{
		return Spawn(prefab, null, position, Quaternion.identity);
	}

	public static T Spawn<T>(T prefab) where T : Component
	{
		return Spawn(prefab, null, Vector3.zero, Quaternion.identity);
	}

	#endregion

	#region 回收物体

	private void DelayRecycle()
	{
		Instance._time++;

		List<Component> readyRecycleObjects = new List<Component>();
		foreach (var item in Instance.recycleObjects)
		{
			if (item.Value <= Instance._time && item.Key != null)
			{
				readyRecycleObjects.Add(item.Key);
			}
		}

		for (int i = 0; i < readyRecycleObjects.Count; i++)
		{
			Recycle(readyRecycleObjects[i]);
		}
	}

	public static void Recycle<T>(T obj) where T : Component
	{
		if (obj != null)
		{
			if (Instance.inUseObjects.ContainsKey(obj))
			{
				var objectDataItem = Instance.unusedObjects[Instance.inUseObjects[obj]];
				objectDataItem.instances.Add(obj);
				Instance.inUseObjects.Remove(obj);
				if (objectDataItem.recycleTime > 0)
				{
					Instance.recycleObjects.Remove(obj);
				}
				obj.transform.SetParent(Instance.transform);
				obj.gameObject.SetActive(false);
			}
			else
			{
				obj.gameObject.SetActive(false);
				Destroy(obj.gameObject);
			}
		}
	}

	public static void RecycleAll()
	{
		List<Component> readyRecycleObjects = new List<Component>();
		foreach (var item in Instance.inUseObjects)
		{
			if (item.Key != null && item.Value != null)
			{
				readyRecycleObjects.Add(item.Key);
			}
		}

		for (int i = 0; i < readyRecycleObjects.Count; i++)
		{
			Recycle(readyRecycleObjects[i]);
		}
	}

	#endregion
}

#region Extensions

public static class ObjectPoolExtensions
{
	public static T Spawn<T>(this T prefab, Transform parent, Vector3 position, Quaternion rotation) where T : Component
	{
		return ObjectPool.Spawn(prefab, parent, position, rotation);
	}
	public static T Spawn<T>(this T prefab, Vector3 position, Quaternion rotation) where T : Component
	{
		return ObjectPool.Spawn(prefab, null, position, rotation);
	}
	public static T Spawn<T>(this T prefab, Vector3 position) where T : Component
	{
		return ObjectPool.Spawn(prefab, null, position, Quaternion.identity);
	}
	public static T Spawn<T>(this T prefab) where T : Component
	{
		return ObjectPool.Spawn(prefab, null, Vector3.zero, Quaternion.identity);
	}
	public static GameObject Spawn(this GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
	{
		Transform transform = ObjectPool.Spawn(prefab.transform, parent, position, rotation);
		return transform ? transform.gameObject : null;
	}
	public static GameObject Spawn(this GameObject prefab, Vector3 position, Quaternion rotation)
	{
		return Spawn(prefab, null, position, rotation);
	}
	public static GameObject Spawn(this GameObject prefab, Vector3 position)
	{
		return Spawn(prefab, null, position, Quaternion.identity);
	}
	public static GameObject Spawn(this GameObject prefab)
	{
		return Spawn(prefab, null, Vector3.zero, Quaternion.identity);
	}
}

#endregion