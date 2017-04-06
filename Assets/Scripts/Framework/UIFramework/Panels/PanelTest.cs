using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTest : PanelBase {

    protected override void InitDate()
    {
        setSkinPath("UI/Panel/" + PanelType.PanelTest.ToString());
    }

    protected override void InitViewDate()
    {
        
    }

    protected override void onClick(GameObject BtObject)
    {
        if (BtObject.name.Equals("BtClose"))
        {
            Close();
        }
    }

}
