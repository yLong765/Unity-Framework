using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr {

    #region 单例

    private static PanelMgr _Instance = new PanelMgr();
    public static PanelMgr Instance
    {
        get { return _Instance; }
    }

    #endregion

    private Transform parentObj = GameObject.Find("Canvas").transform;

    public void openPanel(PanelType panelType, params object[] panelDates)
    {
        string name = panelType.ToString();
        GameObject panel = new GameObject(name);
        panel.transform.parent = parentObj;
        panel.transform.localEulerAngles = Vector3.zero;
        panel.transform.localPosition = Vector3.zero;
        panel.transform.localScale = Vector3.one;
        PanelBase pb = panel.AddComponent(Type.GetType(name)) as PanelBase;
        pb.panelInit();
    }
}
