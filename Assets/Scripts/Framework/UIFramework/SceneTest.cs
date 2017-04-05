using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTest : SceneBase {

    protected override void InitDate()
    {
        setSkinPath("UI/Scene/" + SceneType.SceneTest.ToString());
    }

    protected override void InitViewDate()
    {
        
    }

    protected override void onClick(GameObject BtObject)
    {
        if (BtObject.name.Equals("BtBack"))
        {
            SceneMgr.Instance.returnPrevScene();
        }
    }

}
