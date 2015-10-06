using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {
	void Start () {
	}

	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Thief")){
			SoundAlarm.Instance.ativa = true;
		}
	}
}

