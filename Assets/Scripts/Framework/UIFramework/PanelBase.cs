using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : UIBase {

    protected object[] panelDates;

    protected void panelInit(params object[] _panelDates)
    {
        panelDates = _panelDates;
        Init();
    }

}
