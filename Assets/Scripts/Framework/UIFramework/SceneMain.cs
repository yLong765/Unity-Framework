using UnityEngine;
using UnityEngine.UI;

public class SceneMain : SceneBase {

    private Text playerName;

    protected override void InitDate()
    {
        setSkinPath("UI/Scene/" + SceneType.SceneMain.ToString());
    }

    protected override void InitViewDate()
    {
        playerName = skin.transform.Find("Image/playerName").GetComponent<Text>();
        string name = (string)sceneDates[0];
        playerName.text += name;
    }

    protected override void onClick(GameObject BtObject)
    {
        if (BtObject.name.Equals("BtBack"))
        {
            SceneMgr.Instance.returnPrevScene();
        }
        else if (BtObject.name.Equals("BtNext"))
        {
            SceneMgr.Instance.Sequencer(SceneType.SceneTest);
        }
    }

}
