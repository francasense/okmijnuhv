using UnityEngine;
using System.Collections;

public class CartCollect : MonoBehaviour {

	void Start(){
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Cart")
			col.GetComponent<Cart> ().colectable = false;
	}
}
