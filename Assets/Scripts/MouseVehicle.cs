using UnityEngine;
using System.Collections;

public class MouseVehicle : MonoBehaviour {

	Vector2 lastMouse = new Vector2(-1,-1);

	void Start () {
		//Game.Instance.vehicleManager.vehicles.Add(this);
	}

	void Update () {

		Vector2 mouse = Input.mousePosition;
		if(mouse != lastMouse){
			lastMouse = mouse;

			Ray ray = Camera.main.ScreenPointToRay(mouse);
			foreach(var hit in Physics.RaycastAll(ray)){
				if(hit.collider.CompareTag("Floor")){
					var pos = ray.GetPoint(hit.distance);
					this.GetComponent<NavMeshAgent>().destination = pos;
				}
			}
		}

	}
}
