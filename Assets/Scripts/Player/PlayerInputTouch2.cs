using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInputTouch2 : MonoBehaviour {

	Player player;

	void Start () {
	
		if(!Application.isMobilePlatform)
			this.enabled = false;

		player = GetComponent<Player>();
	}

	int id = -1;

	List<Vector2> positions = new List<Vector2>();

	Vector2 drawLasPos;
	Vector2 drawDir;

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		int touchCount = Input.touchCount;
		for(int t = 0; t < touchCount; t++){
			Touch touch = Input.GetTouch(t);
			if(id == -1 && touch.phase == TouchPhase.Began){
				id = touch.fingerId;
				positions.Clear();
			}else if(touch.fingerId == id){
				switch(touch.phase){
				case TouchPhase.Moved:
					positions.Add(touch.position);
					break;
				case TouchPhase.Canceled:
				case TouchPhase.Ended:
					id = -1;
					positions.Clear();
					break;
				}
			}
		}

		Vector2 lastPos = Vector2.zero;
		Vector2 dir = Vector2.zero;

		if(id != -1){
			if(positions.Count >= 2){
				lastPos = positions[positions.Count-1];
				for(int i = positions.Count-1; i >= 0; i--){
					Vector2 pastPos = positions[i];
					if(Vector2.Distance(lastPos,pastPos) > 50){
						dir = lastPos - pastPos;
						positions.RemoveRange(0,i/2);
						break;
					}
				}
			}
		}

		drawLasPos = lastPos;
		drawDir = dir;

		if(dir != Vector2.zero){

			Vector3 p1 = CalcWorldPoint(lastPos);
			Vector3 p2 = CalcWorldPoint(lastPos+dir);

			if(p1 != Vector3.zero && p2 != Vector3.zero){
				player.destination = player.transform.position + (p2-p1).normalized * 5;
			}
		}else{
			player.destination = player.transform.position;
		}

	}

	void OnGUI(){

		float s1 = 50;
		float s2 = 100;
		Vector2 p1 = drawLasPos;
		Vector2 p2 = drawLasPos-drawDir;

		p1.y = Screen.height-p1.y;
		p2.y = Screen.height-p2.y;

		GUI.Box(new Rect(p1.x-s1/2,p1.y-s1/2,s1,s1), GUIContent.none);
		GUI.Box(new Rect(p2.x-s2/2,p2.y-s2/2,s2,s2), GUIContent.none);
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
