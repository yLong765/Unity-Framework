using System;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour, IEventListener
{
    #region 定义参数

    /// <summary>
    /// 皮肤
    /// </summary>
    private GameObject _skin;
    protected GameObject skin
    {
        get { return _skin; }
        set { _skin = value; }
    }

    /// <summary>
    /// 皮肤地址
    /// </summary>
    private string skinPath = null;
    protected void setSkinPath(string path)
    {
        skinPath = path;
    }

    #endregion

    void Awake() { OnAwake(); }
    void Start() { OnStart(); }
    void Update() { OnUpdate(); }
    void FixedUpdate() { OnFixedUpdate(); }

    #region 初始化方法

    /// <summary>
    /// 初始化皮肤
    /// </summary>
    private void InitSkin()
    {
        if (!string.IsNullOrEmpty(skinPath))
        {
            skin = ResMgr.Instance.LoadGameObject(skinPath, false);
        }
        skin.transform.parent = transform;
        skin.transform.localEulerAngles = Vector3.zero;
        skin.transform.localPosition = Vector3.zero;
        skin.transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    protected void Init()
    {
        InitDate();
        InitSkin();

        Button[] bts = transform.Find("").GetComponentsInChildren<Button>();
        foreach (Button bt in bts)
        {
            UIOnClickListener.Get(bt.gameObject).onClick = onClick;
        }

        InitViewDate();
    }

    #endregion

    #region 虚函数

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }

    /// <summary>
    /// 初始化数据
    /// </summary>
    protected virtual void InitDate() { }
    /// <summary>
    /// 初始化界面数据
    /// </summary>
    protected virtual void InitViewDate() { }
    /// <summary>
    /// 点击事件
    /// </summary>
    /// <param name="BtObject">点击按钮的物体</param>
    protected virtual void onClick(GameObject BtObject) { }
    /// <summary>
    /// 响应事件
    /// </summary>
    /// <param name="message">信息</param>
    protected virtual void resEvent(object[] message) { }

    #endregion

    /// <summary>
    /// 接收事件
    /// </summary>
    /// <param name="message"></param>
    public void Event(params object[] message)
    {
        resEvent(message);
    }

    
}
