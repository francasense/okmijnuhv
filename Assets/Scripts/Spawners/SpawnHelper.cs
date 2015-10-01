using UnityEngine;
using System.Collections;

public class SpawnHelper : MonoBehaviour {
	public GameObject Helper;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Debug.Log ("Ajudante");
		Instantiate (Helper, this.transform.position, Quaternion.identity);
		//Instantiate (Helper);
	}
}
