using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Waypoint : MonoBehaviour {

	public List<Waypoint> nexts;

	public bool parking;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnDrawGizmos(){
		if(nexts != null && nexts.Count > 0){
			Gizmos.color = Color.blue;
			foreach(var w in nexts){
				if(w){
					Gizmos.DrawLine(this.transform.position, w.transform.position);
				}
			}
		}
		if(parking){
			Gizmos.DrawWireCube(this.transform.position, Vector3.one);
		}
	}
}
