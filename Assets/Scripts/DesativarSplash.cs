using UnityEngine;
using System.Collections;

public class DesativarSplash : MonoBehaviour {

	public GameObject splash;
	// Use this for initialization
	void Start () {
		splash.SetActive(true);
		StartCoroutine(desativarSplash());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator desativarSplash() {
		yield return new WaitForSeconds(1.5f);
		splash.SetActive(false);

		
	}
}
