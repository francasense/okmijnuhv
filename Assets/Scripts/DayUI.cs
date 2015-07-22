﻿using UnityEngine;
using System.Collections;

public class DayUI : MonoBehaviour {

	public int day;
	public bool att;

	public GameObject day1;
	public GameObject day2;
	public GameObject day3;
	public GameObject day4;
	public GameObject finalDay;
	public GameObject scorePanel;

	// Use this for initialization
	void Start () {

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
			GameObject newUI = (GameObject)Instantiate (finalDay, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}

		if (day == 6 && att == true) {
			GameObject newUI = (GameObject)Instantiate (scorePanel, this.transform.position, Quaternion.identity);
			newUI.transform.SetParent(this.transform);
			att = false;
		}

	}

}
