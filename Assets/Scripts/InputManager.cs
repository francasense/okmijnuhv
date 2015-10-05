using UnityEngine;
using System.Collections;

public class InputManager: MonoBehaviour {
	GameObject player;
	GameObject helper;

	void Start () {
	
		player = GameObject.Find("Player");
//	  	helper = GameObject.Find("Helper");
	}
	

	void Update () {
		if (Input.GetMouseButtonDown (0) && true) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 pos = hit.point;
				pos.y = 1;
				if( Vector3.Distance(pos, player.transform.position) < 2)
					PlayerControls();
//				if( Vector3.Distance(pos, helper.transform.position) < 2)
//					HelperControls();
				
			}
		}
	}

	void PlayerControls(){
		if(player.GetComponent<PlayerInputMouse> ().enabled == false)
		player.GetComponent<PlayerInputMouse> ().enabled = true;
//		if(helper.GetComponent<PlayerInputMouse> ().enabled == true)
//		helper.GetComponent<PlayerInputMouse> ().enabled = false;
	}

	void HelperControls(){
//		if(helper.GetComponent<PlayerInputMouse> ().enabled == false)
//		helper.GetComponent<PlayerInputMouse> ().enabled = true;
		if(player.GetComponent<PlayerInputMouse> ().enabled == true)
		player.GetComponent<PlayerInputMouse> ().enabled = false;
	}
}
