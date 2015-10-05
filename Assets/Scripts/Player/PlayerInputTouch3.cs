using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInputTouch3 : MonoBehaviour {

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

		int touchCount = Input.touchCount;
		for(int t = 0; t < touchCount; t++){
			Touch touch = Input.GetTouch(t);
			switch(touch.phase){
			case TouchPhase.Began:
			case TouchPhase.Moved:
				player.destination = CalcWorldPoint(touch.position);
				break;
			}
		}

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
