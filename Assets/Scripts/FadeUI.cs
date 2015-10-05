using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().CrossFadeAlpha (0f, 3f, false);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
