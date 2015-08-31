using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {


	// Use this for initialization
	void Start () {

		//int teste = PlayerPrefs.GetInt("level");
		//PlayerPrefs.SetInt("level",teste);
	
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
	public void menu_level() {
		Application.LoadLevel("menu_level");
	}
	public void creditos() {
		Application.LoadLevel("creditos");
	}

	public void inGameLevel1() {
		PlayerPrefs.SetInt("level",1);
		Application.LoadLevel("Game");
	}
}