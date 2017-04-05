using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr
{
    #region 单例&初始化

    private static SceneMgr _Instance = new SceneMgr();
    public static SceneMgr Instance
    {
        get { return _Instance; }
    }

    public SceneMgr()
    {
        sceneList = new List<sceneCache>();
    }

    #endregion

    #region 定义参数

    /// <summary>
    /// 父物体
    /// </summary>
    private Transform parentObj = GameObject.Find("Canvas").transform;

    /// <summary>
    /// 上一场景
    /// </summary>
    private GameObject prevScene = null;

    /// <summary>
    /// 场景缓存
    /// </summary>
    internal struct sceneCache
    {
        internal string sceneName;
        internal object[] sceneDates;

        internal sceneCache(string name, object[] dates)
        {
            sceneName = name;
            sceneDates = dates;
        }
    }

    /// <summary>
    /// 场景缓存列表
    /// </summary>
    private List<sceneCache> sceneList;

    #endregion

    /// <summary>
    /// 获取到上一个场景
    /// </summary>
    /// <returns></returns>
    private sceneCache GetPrveScene()
    {
        sceneCache sc = sceneList[sceneList.Count - 2];
        sceneList.RemoveAt(sceneList.Count - 1);
        return sc;
    }
    
    #region 切换场景方法

    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="sceneType">场景类型</param>
    /// <param name="sceneDates">传参</param>
    public void Sequencer(SceneType sceneType, params object[] sceneDates)
    {
        string name = sceneType.ToString();
        InitScene(name, sceneDates);

        sceneList.Add(new sceneCache(name, sceneDates));
    }

    /// <summary>
    /// 返回上一场景
    /// </summary>
    public void returnPrevScene()
    {
        sceneCache sc = GetPrveScene();

        string name = sc.sceneName;
        object[] sceneDates = sc.sceneDates;
        InitScene(name, sceneDates);
    }

    /// <summary>
    /// 场景实例初始化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sceneDates"></param>
    private void InitScene(string name, params object[] sceneDates)
    {
        GameObject scene = new GameObject(name);
        scene.transform.parent = parentObj;
        scene.transform.localPosition = Vector3.zero;
        scene.transform.localEulerAngles = Vector3.zero;
        scene.transform.localScale = Vector3.one;
        SceneBase sb = scene.AddComponent(Type.GetType(name)) as SceneBase;
        sb.sceneInit(sceneDates);

        if (prevScene != null)
        {
            UnityEngine.Object.Destroy(prevScene);
        }

        prevScene = scene;
    }

    #endregion
}
