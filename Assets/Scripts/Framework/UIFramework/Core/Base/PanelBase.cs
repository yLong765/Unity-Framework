using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : UIBase {

    protected object[] panelDates;

    public void panelInit(params object[] _panelDates)
    {
        panelDates = _panelDates;
        Init();
    }

    protected void Close()
    {
        Destroy(gameObject);
    }

}

public enum PanelType
{
    /// <summary>
    /// 测试Panel
    /// </summary>
    PanelTest,
}
