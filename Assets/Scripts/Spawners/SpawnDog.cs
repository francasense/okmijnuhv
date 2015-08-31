using UnityEngine;
using System.Collections;

public class SpawnDog : MonoBehaviour {
	public GameObject Dog;
	public GameObject Pau;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(){
		Debug.Log ("Dog");
		Instantiate (Dog, this.transform.position, Quaternion.identity);
		//Instantiate (Pau,GameObject.Find("t04").transform.position, Quaternion.identity);
	}
}
