using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class TransformExtensions {

	public static Transform[] GetChildren(this Transform t){
		Transform[] ts = new Transform[t.childCount];
		for(int i = 0; i < ts.Length; i++){
			ts[i] = t.GetChild(i);
		}
		return ts;
	}

}
