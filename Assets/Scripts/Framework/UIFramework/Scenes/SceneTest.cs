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
        else if (BtObject.name.Equals("BtSendMessage"))
        {
            EventInfo info = new EventInfo(EventCode.toLogic, "终于理解消息机制系列");
            SceneMgr.Instance.SendMessage(info);
        }
    }

    protected override void resEvent(object[] message)
    {
        Debug.Log("Test: " + message[0]);
    }

}
