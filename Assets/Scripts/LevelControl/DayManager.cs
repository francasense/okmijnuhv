using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {

	private static DayManager instance;
	public static DayManager Instance{get{return instance == null ? instance = FindObjectOfType<DayManager>() : instance;}}
	public LevelControl levelControl;
	public bool dayflag;
	public int carsOnScene;
	public float dayLength = 15f;
	public float dayTime = 0f;
	public float nightTime = 0f;
	public int dayday1;
	
	void Start () {

		StartCoroutine(carreharValores());
	}

	void Update(){

		//dayday1 = levelControl.dayday;

		//Verifica carros na Cena.
		carsOnScene = GameObject.FindGameObjectsWithTag ("Vehicle").Length;

		//Chama o Proximo dia quando dia tiver acabado e nao restar nenhum carro.
		if (dayflag /*&& carsOnScene <= 0*/) {
			StartCoroutine(DayCountCoroutine());
			dayflag = false;
		}

	}

	IEnumerator carreharValores(){
		yield return new WaitForSeconds(2.5f);
		dayday1 = LevelControl.Instance.dayday;

		
	}
	//Chama inicio do dia e depois de X segundos emite flag parando produçao de Vehiculos e Ativa Flag do proximo dia.
	IEnumerator DayCountCoroutine(){
		yield return new WaitForSeconds(2);

		dayTime = levelControl.dayTime1;
		nightTime = levelControl.nightTime1;


		GameObject.Find ("Directional light").GetComponent<Animator> ().SetBool("Sun", true);
			DayStart();
			yield return new WaitForSeconds(dayTime);
		GameObject.Find ("Directional light").GetComponent<Animator> ().SetBool("Sun", false);
			yield return new WaitForSeconds(nightTime);
			//GameObject.Find ("Vehicles").GetComponent<VehicleManager> ().vehicleflag = false;
			//dayflag = true;

	}

	//Inicia o Dia definindo a Flag de Veiculos para Ligado e Atualizando UI.                                                                                   //0.3f
	void DayStart(){
		//GameObject.Find("Vehicles").GetComponent<VehicleManager>().currentTimeStep = GameObject.Find("Vehicles").GetComponent<VehicleManager>().currentTimeStep - 1.2f;
		StartCoroutine (dayday());
		
	}

	IEnumerator dayday() {
		yield return new WaitForSeconds(2f);

		GameObject.Find("DayCount").GetComponent<DayUI>().day = dayday1;
		GameObject.Find("DayCount").GetComponent<DayUI>().att = true;
	}
	

}
