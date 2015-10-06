using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {


	void Start () {
		//PlayerPrefs.SetInt("points", 0);
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
	public void inGameLevel2() {
		PlayerPrefs.SetInt("level",2);
		Application.LoadLevel("Game");
	}
	public void inGameLevel3() {
		PlayerPrefs.SetInt("level",3);
		Application.LoadLevel("Game");
	}
	public void inGameLevel4() {
		PlayerPrefs.SetInt("level",4);
		Application.LoadLevel("Game");
	}
	public void inGameLevel5() {
		PlayerPrefs.SetInt("level",5);
		Application.LoadLevel("Game");
	}
	public void inGameLevel6() {
		PlayerPrefs.SetInt("level",6);
		Application.LoadLevel("Game");
	}
	public void inGameLevel7() {
		PlayerPrefs.SetInt("level",7);
		Application.LoadLevel("Game");
	}
	public void inGameLevel8() {
		PlayerPrefs.SetInt("level",8);
		Application.LoadLevel("Game");
	}
	public void inGameLevel9() {
		PlayerPrefs.SetInt("level",9);
		Application.LoadLevel("Game");
	}
	public void inGameLevel10() {
		PlayerPrefs.SetInt("level",10);
		Application.LoadLevel("Game");
	}
	public void inGameLevel11() {
		PlayerPrefs.SetInt("level",11);
		Application.LoadLevel("Game");
	}
	public void inGameLevel12() {
		PlayerPrefs.SetInt("level",12);
		Application.LoadLevel("Game");
	}

	public void NextLevel(){

		Time.timeScale = 1f;
		PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level")+1);
		Application.LoadLevel("Game");
	}


























}