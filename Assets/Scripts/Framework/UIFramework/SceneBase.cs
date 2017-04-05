using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : UIBase {

    /// <summary>
    /// 场景数据
    /// </summary>
    protected object[] sceneDates;

    /// <summary>
    /// 场景初始化
    /// </summary>
    /// <param name="_sceneDates">场景数据</param>
    public void sceneInit(params object[] _sceneDates)
    {
        sceneDates = _sceneDates;
        Init();
    }

}

/// <summary>
/// 界面枚举
/// </summary>
public enum SceneType
{
    /// <summary>
    /// 登陆界面
    /// </summary>
    SceneLogin,

    /// <summary>
    /// 主界面
    /// </summary>
    SceneMain,

    SceneTest,
}
