using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {
	public bool dayflag;
	public int carsOnScene;
	public float dayLength = 15f;
	void Start () {

		dayflag = true;

	}
	
	void Update(){
		//Verifica carros na Cena.
		carsOnScene = GameObject.FindGameObjectsWithTag ("Vehicle").Length;

		//Chama o Proximo dia quando dia tiver acabado e nao restar nenhum carro.
		if (dayflag && carsOnScene <= 0) {
			StartCoroutine(DayCountCoroutine());
			dayflag = false;
		}

	}
	
	//Chama inicio do dia e depois de X segundos emite flag parando produçao de Vehiculos e Ativa Flag do proximo dia.
	IEnumerator DayCountCoroutine(){

		GameObject.Find ("Directional light").GetComponent<Animator> ().SetBool("Sun", true);
			DayStart();
			yield return new WaitForSeconds(dayLength);
			//GameObject.Find("Vehicles").GetComponent<VehicleManager>().currentTimeStep = 99999;
			GameObject.Find ("Vehicles").GetComponent<VehicleManager> ().vehicleflag = false;
			dayflag = true;
		GameObject.Find ("Directional light").GetComponent<Animator> ().SetBool("Sun", false);
	}

	//Inicia o Dia definindo a Flag de Veiculos para Ligado e Atualizando UI.                                                                                   //0.3f
	void DayStart(){
		GameObject.Find("Vehicles").GetComponent<VehicleManager>().currentTimeStep = GameObject.Find("Vehicles").GetComponent<VehicleManager>().currentTimeStep - 0.8f;

		GameObject.Find ("Vehicles").GetComponent<VehicleManager> ().CoroutineRecaller = true;
		GameObject.Find("DayCount").GetComponent<DayUI>().day = GameObject.Find("DayCount").GetComponent<DayUI>().day + 1;
		GameObject.Find("DayCount").GetComponent<DayUI>().att = true;
	}
	

}
