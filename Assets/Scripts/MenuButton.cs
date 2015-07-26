using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void inGame() {
		Application.LoadLevel("Game");
	}
	public void inMenu() {
		Application.LoadLevel("menu");
	}
	public void inCutscene() {
		Application.LoadLevel("cutscene");
	}
}
