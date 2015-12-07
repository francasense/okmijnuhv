using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInputTouch4 : MonoBehaviour {

	Player player;

	void Start () {
	
		if(!Application.isMobilePlatform)
			this.enabled = false;

		player = GetComponent<Player>();

	}

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		Vector2 center = new Vector2(Screen.width/2,Screen.height/2);
		Vector2 dir = new Vector2(h,v);
		Vector3 p1 = CalcWorldPoint(center);
		Vector3 p2 = CalcWorldPoint(center+dir);

		player.destination = player.transform.position + (p2-p1).normalized;

	}

	Vector3 CalcWorldPoint(Vector2 screenPoint){
		Ray ray = Camera.main.ScreenPointToRay(screenPoint);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)){
			Vector3 pos = hit.point;
			pos.y = 1;
			return pos;
		}
		return Vector3.zero;
	}

}
