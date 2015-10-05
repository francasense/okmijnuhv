using UnityEngine;
using System.Collections;

public class PainelMatherTurtorial : MonoBehaviour {

	// Use this for initialization
	public GameObject panelMather;
	void Start () {
		panelMather.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider theCollision)
	{
		
		if (theCollision.tag == "Player"){
			panelMather.SetActive(true);

		}
	
	}
	void OnTriggerExit(Collider theCollision)
	{
		
		if (theCollision.tag == "Player"){
			panelMather.SetActive(false);
			
		}
		
	}
}
