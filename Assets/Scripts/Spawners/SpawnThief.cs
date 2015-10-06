using UnityEngine;
using System.Collections;

public class SpawnThief : MonoBehaviour {
	public GameObject Thief;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Debug.Log ("Ladrao");
		Instantiate (Thief, this.transform.position, Quaternion.identity);
		//Instantiate (Thief);
	}
}
