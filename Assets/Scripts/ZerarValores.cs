using UnityEngine;
using System.Collections;

public class ZerarValores : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("moedas", 0);
        PlayerPrefs.SetInt("valorMoedas", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
