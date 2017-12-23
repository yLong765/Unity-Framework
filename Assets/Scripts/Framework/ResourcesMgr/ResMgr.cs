using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResMgr : MonoSingletonMgr<ResMgr>
{
    #region 定义参数

    /// <summary>
    /// 资源缓存池
    /// </summary>
    private static Hashtable resCache = new Hashtable();

    #endregion

    #region 加载资源&&实例化资源 函数

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源地址</param>
    /// <param name="isCache">是否缓存</param>
    /// <returns>资源or空</returns>
    public T Load<T>(string path, bool isCache) where T : Object
    {
        if (resCache.Contains(path))
        {
            return resCache[path] as T;
        }

        T resObj = Resources.Load<T>(path);

        if (resObj == null)
        {
            Debug.LogError("资源不存在 path: " + path);
            return null;
        }

        if (isCache)
        {
            resCache.Add(path, resObj);
        }

        return resObj;
    }

    /// <summary>
    /// 加载物体
    /// </summary>
    /// <param name="path">加载地址</param>
    /// <param name="isCache">是否缓存</param>
    /// <returns>物体</returns>
    public GameObject LoadGameObject(string path, bool isCache)
    {
        GameObject go = Instantiate(Load<GameObject>(path, isCache)) as GameObject;
        return go;
    }

    /// <summary>
    /// 加载音频
    /// </summary>
    /// <param name="path">加载地址</param>
    /// <param name="isCache">是否缓存</param>
    /// <returns>音频</returns>
    public AudioClip LoadAudio(string path, bool isCache)
    {
        AudioClip ac = Load<AudioClip>(path, isCache);
        return Instantiate(ac) as AudioClip;
    }

    #endregion
}
