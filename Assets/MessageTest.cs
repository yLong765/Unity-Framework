using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour, IEventListener {

    public void Event(params object[] message)
    {
        Debug.Log(message[0]);
    }

    // Use this for initialization
    void Start () {
        SceneMgr.Instance.AddListener(EventCode.toLogic, this);
	}

    public void SendMessage()
    {
        EventInfo info = new EventInfo(EventCode.toScene, "这是一个发往UI的测试消息");
        SceneMgr.Instance.SendMessage(info);
    }
	
}
