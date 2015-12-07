using UnityEngine;
using System.Collections;

public class Principal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public void inCutscene() {
		StartCoroutine(zerarValores());
		//Application.LoadLevel("cutscene");
		
	}
	public void creditos() {
		Application.LoadLevel("creditos");
	}
	
	
	IEnumerator zerarValores()
	{
		//PlayerPrefs.SetInt("moedas", 0);
		//PlayerPrefs.SetInt("valorMoedas", 0);
		yield return new WaitForSeconds(2f);
		Application.LoadLevel("cutscene");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
