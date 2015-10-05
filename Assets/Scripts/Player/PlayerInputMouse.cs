using UnityEngine;
using System.Collections;

public class PlayerInputMouse : MonoBehaviour {

	Player player;
	public Transform circulo;

	void Start () {

		//if(!Application.isMobilePlatform)
		//	this.enabled = false;

		player = GetComponent<Player>();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0) && true){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)){
				Vector3 pos = hit.point;
				pos.y = 1;
				if( Vector3.Distance(pos, player.transform.position) > 1){
					Instantiate(circulo, pos, Quaternion.identity);
					Instantiate(circulo, pos, Quaternion.identity);
					player.destination = pos;
				}
			}
		}
	}
}
