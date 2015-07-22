using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	public float Tempo;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, Tempo);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
