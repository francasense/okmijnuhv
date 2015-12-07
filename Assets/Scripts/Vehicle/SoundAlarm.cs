using UnityEngine;
using System.Collections;

public class SoundAlarm : MonoBehaviour {
	private static SoundAlarm instance;
	public static SoundAlarm Instance{get{return instance == null ? instance = FindObjectOfType<SoundAlarm>() : instance;}}

	public GameObject soundLadrão;
	bool soundAlarm;
	public bool ativa;

	// Use this for initialization
	void Start () {
		ativa = false;
		soundAlarm = false;
		soundLadrão.SetActive(false);

	}
	void Update () {
		soundAlarm = ativa;
		if(soundAlarm){
			ativaAlarm();
		}
		if(!soundAlarm){
			desativaAlarm();
		}

	}

	public void ativaAlarm(){
		soundLadrão.SetActive(true);
	}
	public void desativaAlarm(){
		soundLadrão.SetActive(false);
	}
}
