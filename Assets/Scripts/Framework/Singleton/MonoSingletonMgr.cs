using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonMgr<T> : MonoBehaviour where T : Component
{

	private static T _Instance;
	public static T Instance
	{
		get
		{
			if (_Instance == null)
			{
				GameObject obj = new GameObject("_" + typeof(T).Name);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
				_Instance = obj.AddComponent<T>() as T;
				DontDestroyOnLoad(obj);
			}
			return _Instance;
		}
	}

}
