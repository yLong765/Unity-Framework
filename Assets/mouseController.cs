using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.name.Equals("Cube"))
                {
                    _hit.collider.gameObject.GetComponent<MessageTest>().SendMessage();
                }
            }
        }
	}
}
