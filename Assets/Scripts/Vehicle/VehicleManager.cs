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

	private float startTimeStep;
	private float endTimeStep;
	private float totalTime;//1min
	private float currentTimeStep;

	public float timeStepVariation = 2f;

	public bool vehicleflag;
	public bool CoroutineRecaller;

	void Start () {

		//CoroutineRecaller = false;
		//vehicleflag = true;
		//currentTimeStep = startTimeStep;

		//currentTimeStep = LevelControl.Instance.startTimeStep;
		StartCoroutine(CreateVehicleCoroutine());
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

	IEnumerator CreateVehicleCoroutine(){

		currentTimeStep = LevelControl.Instance.startTimeStep;
		//	while (vehicleflag) {
			while (true) {

			yield return new WaitForSeconds (10f);

				currentTimeStep = Mathf.MoveTowards (
				currentTimeStep, 
				//endTimeStep,
				LevelControl.Instance.endTimeStep,
				currentTimeStep * Mathf.Abs (LevelControl.Instance.endTimeStep - LevelControl.Instance.startTimeStep) / LevelControl.Instance.totalTime);

				//currentTimeStep * Mathf.Abs (endTimeStep - startTimeStep) / totalTime);


				float time = currentTimeStep;
				//time += Random.Range (-timeStepVariation, timeStepVariation) / 2;

				time += Random.Range (-LevelControl.Instance.timeStepVariation, LevelControl.Instance.timeStepVariation) / 2;
				time = Mathf.Clamp (time, 0, time);

				//Debug.Log(string.Format("{0}s -> {1}s", currentTimeStep, time));

				yield return new WaitForSeconds (time);
				Vehicle newVehicle = (Vehicle)Instantiate (vehiclePrefab, Game.Instance.enter.position, Game.Instance.enter.rotation);
				newVehicle.transform.SetParent (this.transform);
			}

	}

}
