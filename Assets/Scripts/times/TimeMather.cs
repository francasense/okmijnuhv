using UnityEngine;
using System.Collections;

public class TimeMather : MonoBehaviour {

	private static TimeMather instance;
	public static TimeMather Instance{ get{ return instance == null ? (instance = FindObjectOfType<TimeMather>()) : instance; } }
	public GameObject texttime;
	public GameObject timeAlert;
	public GameObject alerta_panel;
	public UnityEngine.UI.Text timeMather;
	public bool valendo;
	public GameObject carrinhodobebe;
	public Cart cart;
	int segundos;
 
	void Start () {
		alerta_panel.SetActive(false);
		texttime.SetActive(false);
		timeAlert.SetActive(false);
		valendo = false;
	}

	public void chamarRelogio(){
		alerta_panel.SetActive(true);
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
		//Debug.Log("segundos"+segundos);

		//timeMather.text = " "+segundos;
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

	}
	IEnumerator destroyObj(){

		yield return new WaitForSeconds(29f);
		TimeDog.Instance.valendofalso();
		alerta_panel.SetActive(false);
		TimeCentral.Instance.tcorrido = 1f;
		Destroy (GameObject.FindWithTag("Matherbaby"));
		cart.DetachFrom();
		carrinhodobebe.SetActive(false);
		TimeCentral.Instance.alerta = false;
		texttime.SetActive(false);
		timeAlert.SetActive(false);
		valendo = false;
	}
}