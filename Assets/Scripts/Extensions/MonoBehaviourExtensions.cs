using UnityEngine;
using System.Collections;

public static class MonoBehaviourExtensions {

	public delegate void InvokeMethod();

	public static void Invoke(this MonoBehaviour behaviour, InvokeMethod method, float time){
		behaviour.Invoke(method.Method.Name, time);
	}

}
