using UnityEngine;
using System.Collections;

public class DasableCartBaby : MonoBehaviour {
	//public GameObject desativarscript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){

			this.gameObject.GetComponent<Move>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().isTrigger = false;

			//camera.main.gameObject.GetComponent(MouseOrbit).enabled = true ;
			
		
		}
	}
}
