using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

	public List<Waypoints> nexts;

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		foreach(Waypoints next in nexts){
			Gizmos.DrawLine(
				this.transform.position,
				next.transform.position);
		}
	}

}
