using UnityEngine;
using System.Collections;

public class DayUI : MonoBehaviour {

	public int day;
	public bool att;

	public GameObject day1;
	public GameObject day2;
	public GameObject day3;
	public GameObject day4;
	public GameObject day5;
	public GameObject day6;
	public GameObject day7;
	public GameObject day8;
	public GameObject day9;
	public GameObject day10;
	public GameObject day11;
	public GameObject day12;


	// Use this for initialization
	void Start () {
		//day = 1;
		//att = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (day == 1 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day1, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}

		if (day == 2 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day2, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}

		if (day == 3 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day3, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 4 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day4, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 5 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day5, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 6 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day6, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 7 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day7, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 8 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day8, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 9 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day9, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 10 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day10, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 11 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day11, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}
		if (day == 12 && att == true) {
			GameObject newUI = (GameObject)Instantiate (day12, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}

	}

}
