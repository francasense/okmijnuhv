using UnityEngine;
using System.Collections;

public class SpawnMother : MonoBehaviour {
	public GameObject Mother;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Debug.Log ("Mae aqui");
		Instantiate (Mother);

	}
}
