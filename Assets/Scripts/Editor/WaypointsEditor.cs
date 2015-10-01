using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Waypoints))]
[CanEditMultipleObjects]
public class WaypointsEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector();

		if(targets.Length > 1){
			//varios

			if(GUILayout.Button("Rename")){
				Waypoints[] waypoints = ConvertTargets(targets);
				for(int i = 0; i < waypoints.Length; i++){
					waypoints[i].name = "W"+(i+1);
				}
			}

			if(GUILayout.Button("Link")){
				Waypoints[] waypoints = ConvertTargets(targets);
				for(int i = 0; i < waypoints.Length; i++){
					var wi = waypoints[i];
					for(int j = i+1; j < waypoints.Length; j++){
						var wj = waypoints[j];
						if(!wi.nexts.Contains(wj)){
							wi.nexts.Add(wj);
							EditorUtility.SetDirty(wi);
						}
						if(!wj.nexts.Contains(wi)){
							wj.nexts.Add(wi);
							EditorUtility.SetDirty(wj);
						}
					}
				}
			}
			if(GUILayout.Button("Unlink")){
				Waypoints[] waypoints = ConvertTargets(targets);
				for(int i = 0; i < waypoints.Length; i++){
					var wi = waypoints[i];
					for(int j = i+1; j < waypoints.Length; j++){
						var wj = waypoints[j];
						if(wi.nexts.Contains(wj)){
							wi.nexts.Remove(wj);
							EditorUtility.SetDirty(wi);
						}
						if(wj.nexts.Contains(wi)){
							wj.nexts.Remove(wi);
							EditorUtility.SetDirty(wj);
						}
					}
				}
			}
		}else{
			//so 1
		}
	}

	Waypoints[] ConvertTargets(Object[] targets){
		Waypoints[] result =new Waypoints[targets.Length];
		for(int i = 0; i < targets.Length; i++){
			result[i] = targets[i] as Waypoints;
		}
		return result;
	}

}
