using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingletonBase
{
    void Init();
	/// <summary>
	/// 初始化函数
	/// </summary>
    void OnInit();
    /// <summary>
    /// 通过重写此方法来控制显示方式
    /// </summary>
    HideFlags GetFlag();
    /// <summary>
    /// 通过重写此方法来控制是否久存
    /// </summary>
    bool LoadDontDestroy();
}

public class MonoSingletonMgr<T> : MonoBehaviour, ISingletonBase where T : Component, ISingletonBase
{
    public static bool Created = false;
    public static bool Initialized = false;

    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Create();
            }
            return _instance;
        }
    }

    public static T Create()
    {
        GameObject obj = FindObjectOfType<T>() as GameObject; // 保证永久唯一
        if (obj == null)
        {
            obj = new GameObject(typeof(T).Name);
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            _instance = obj.AddComponent(typeof(T)) as T;
            if (_instance.LoadDontDestroy())
            {
                DontDestroyOnLoad(obj);
            }
            _instance.Init();
            Created = true;
        }
        return _instance;
    }

    public HideFlags GetFlag() { return HideFlags.HideInHierarchy; }

    public void Init()
    {
        if (!Initialized)
		{
            Debug.Log(typeof(T).ToString() + " init.");
            OnInit();
            Initialized = true;
        }
    }

    public virtual void OnInit() { }

    public bool LoadDontDestroy() { return true; }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
    }

}
