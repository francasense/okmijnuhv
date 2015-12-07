using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GameObject sound;
	public GameObject soundSad;
	
	// Use this for initialization
	void Start () {
		
		sound.SetActive(false);
		soundSad.SetActive(true);
		StartCoroutine(callGame());
		StartCoroutine(callSound());
		
		
	}
	
	
	//IEnumerator callMenu() {
	//yield return new WaitForSeconds(45f);
	//Application.LoadLevel("menu");
	
	
	//}
	
	IEnumerator callGame() {
		yield return new WaitForSeconds(45f);
		Application.LoadLevel("menu");
		
		
	}
	
	public void chamarGame() {
		Application.LoadLevel("menu");
		
	}
	
	IEnumerator callSound() {
		yield return new WaitForSeconds(54f);
		soundSad.SetActive(false);
		sound.SetActive(true);
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	
	
	
}
