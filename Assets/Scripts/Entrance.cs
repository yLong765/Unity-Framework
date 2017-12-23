using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{

    private GameObject Cube;
    public Transform parent;

    void Start()
    {
        // 界面模块
        SceneMgr.Instance.Sequencer(SceneType.SceneLogin);

        // 对象池初始化
        Cube = ResMgr.Instance.Load<GameObject>("Object/Cube", false);
        ObjectPool.InitPool(Cube, 5, 10);
        InvokeRepeating("CreateCube", 1, 1);
    }

    void CreateCube()
    {
        Cube.Spawn(parent, new Vector3(0, 4, 0), Quaternion.identity);
    }

}
