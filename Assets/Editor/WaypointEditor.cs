using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector();

		if(targets.Length == 2){
			if(GUILayout.Button("Link")){
				Waypoint w1 = (Waypoint)targets[0];
				Waypoint w2 = (Waypoint)targets[1];
				if(!w1.nexts.Contains(w2))
					w1.nexts.Add(w2);
				if(!w2.nexts.Contains(w1))
					w2.nexts.Add(w1);
			}
			if(GUILayout.Button("Unlink")){
				Waypoint w1 = (Waypoint)targets[0];
				Waypoint w2 = (Waypoint)targets[1];
				if(w1.nexts.Contains(w2))
					w1.nexts.Remove(w2);
				if(w2.nexts.Contains(w1))
					w2.nexts.Remove(w1);
			}
		}

	}

}
