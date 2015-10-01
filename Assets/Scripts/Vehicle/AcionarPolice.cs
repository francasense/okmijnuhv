using UnityEngine;
using System.Collections;

public class AcionarPolice : MonoBehaviour {

	public GameObject cops;
	// Use this for initialization
	void Start () {
		cops.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")){
			cops.SetActive(true);
		}
	}

}
