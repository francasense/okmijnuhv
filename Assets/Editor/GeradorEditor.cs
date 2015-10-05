using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Gerador))]
public class GeradorEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector();

		Gerador gerador = (Gerador)target;

		if(GUILayout.Button("Make")){
			gerador.Remake();
		}

	}

}
