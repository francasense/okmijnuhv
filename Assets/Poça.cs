using UnityEngine;
using System.Collections;

public class Poça : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col){

		if (col.tag == "Player") {
			col.GetComponent<Player>().speed = 3f;
		}

		if (col.tag == "Pedestrian") {
			col.GetComponent<NavMeshAgent>().speed = 2.0f;
		}

	}

	void OnTriggerExit(Collider col){
		
		if (col.tag == "Player") {
			col.GetComponent<Player>().speed = 7f;
		}

		if (col.tag == "Pedestrian") {
			col.GetComponent<NavMeshAgent>().speed = 3.5f;
		}
	}


	void FimDaPoca(){
		Destroy (this.gameObject);
	}

}
