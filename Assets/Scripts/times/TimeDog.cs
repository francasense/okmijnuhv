using UnityEngine;
using System.Collections;

public class TimeDog : MonoBehaviour {

	private static TimeDog instance;
	public static TimeDog Instance{ get{ return instance == null ? (instance = FindObjectOfType<TimeDog>()) : instance; } }
	public GameObject texttime;
	public GameObject timeAlert;
	public GameObject panelAlert;

	public GameObject alerta_panel;
	public UnityEngine.UI.Text TimeM;
	public bool valendo;
	//public GameObject cachorro;
	
	int segundos;
 
	void Start () {
		panelAlert.SetActive(false);
		alerta_panel.SetActive(false);
		texttime.SetActive(false);
		timeAlert.SetActive(false);
		valendo = false;
	}

	public void chamarRelogio(){
		alerta_panel.SetActive(true);
		panelAlert.SetActive(true);

		valendo = true;
		segundos = 29;
		texttime.SetActive(true);
		timeAlert.SetActive(true);
		TimeCentral.Instance.tcorrido = 0.5f;
		TimeCentral.Instance.alerta = true;
		StartCoroutine(Cronometro());
		StartCoroutine(destroyObj());
	}
	void Update () {
		TimeM.text = " "+segundos;
	}
	IEnumerator Cronometro(){
		yield return new WaitForSeconds(1f);
		segundos--;
	
		if (valendo){
		StartCoroutine(CronometroSegundos());
		}
	}
	IEnumerator CronometroSegundos(){
		yield return new WaitForSeconds(1f);
		segundos--;
		if (valendo){
		StartCoroutine(Cronometro());
		}
	}

	public void valendofalso(){
		valendo = false;
		texttime.SetActive(false);
		timeAlert.SetActive(false);
		alerta_panel.SetActive(false);
		panelAlert.SetActive(false);

		TimeCentral.Instance.alerta = false;
		TimeCentral.Instance.tcorrido = 1f;

	}

	IEnumerator destroyObj(){
		yield return new WaitForSeconds(29f);
		//Destroy (GameObject.FindWithTag("Dog"));
		alerta_panel.SetActive(false);
		TimeCentral.Instance.tcorrido = 1f;
		TimeCentral.Instance.alerta = false;
		texttime.SetActive(false);
		timeAlert.SetActive(false);
		panelAlert.SetActive(false);

		valendo = false;
	}
}