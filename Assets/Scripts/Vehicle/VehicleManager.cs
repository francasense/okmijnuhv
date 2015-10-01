using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VehicleManager : MonoBehaviour {
	private static VehicleManager instance;
	public static VehicleManager Instance{get{return instance == null ? instance = FindObjectOfType<VehicleManager>() : instance;}}
	
	public Vehicle vehiclePrefab;
	
	[HideInInspector]
	public List<Vehicle> vehicles;
	//LevelControl lc = LevelControl.Instance;
	
	//public float startTimeStep;
	//public float endTimeStep;
	//public float totalTime;//1min
	float currentTimeStep;
	
	//public float timeStepVariation = 2f;
	
	public bool vehicleflag;
	public bool CoroutineRecaller;
	
	//public float dificuldade = 20;
	//	public float temp;
	void Start () {
		//float temp = LevelControl.Instance.dificuldade;
		//CoroutineRecaller = false;
		//vehicleflag = true;
		//currentTimeStep = startTimeStep;
		
		StartCoroutine(instaciarCriacaoCarro());


	}
	
	void Update () {
		//if (CoroutineRecaller == true){
		//vehicleflag = true;
		//currentTimeStep = startTimeStep;
		//	currentTimeStep = currentTimeStep;
		//	StartCoroutine(CreateVehicleCoroutine());
		//	CoroutineRecaller = false;
		//}
		
	}

	IEnumerator instaciarCriacaoCarro(){
		yield return new WaitForSeconds (0.5f);
		currentTimeStep = LevelControl.Instance.startTimeStep;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine(CreateVehicleCoroutine());
	}
	
	IEnumerator CreateVehicleCoroutine(){
		
		currentTimeStep = LevelControl.Instance.startTimeStep;
		
		while (true) {
			yield return new WaitForSeconds (1f);
			
			
			currentTimeStep = Mathf.MoveTowards (
				currentTimeStep, 
				LevelControl.Instance.endTimeStep,
				currentTimeStep * Mathf.Abs (LevelControl.Instance.endTimeStep - LevelControl.Instance.startTimeStep) / LevelControl.Instance.totalTime);
			
			
			float time = currentTimeStep;
			
			time += Random.Range (-LevelControl.Instance.timeStepVariation, LevelControl.Instance.timeStepVariation) / 2;
			time = Mathf.Clamp (time, 0, time);
			
			
			yield return new WaitForSeconds (time);
			Vehicle newVehicle = (Vehicle)Instantiate (vehiclePrefab, Game.Instance.enter.position, Game.Instance.enter.rotation);
			newVehicle.transform.SetParent (this.transform);
		}
		
	}
	
}
