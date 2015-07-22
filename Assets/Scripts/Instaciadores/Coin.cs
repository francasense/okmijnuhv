﻿using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			GerenciarExtras.Instance.AddCoin(1);
			Destroy(gameObject);
			
		}
	}
}
