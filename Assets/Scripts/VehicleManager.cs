using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VehicleManager : MonoBehaviour {

	public Vehicle vehiclePrefab;

	[HideInInspector]
	public List<Vehicle> vehicles;

	public float startTimeStep = 5f;
	public float endTimeStep = 1f;
	public float totalTime = 60f;//1min
	public float currentTimeStep;

	public float timeStepVariation = 2f;

	public bool vehicleflag;
	public bool CoroutineRecaller;

	void Start () {
		CoroutineRecaller = false;
		vehicleflag = true;
		currentTimeStep = startTimeStep;
		StartCoroutine(CreateVehicleCoroutine());
	}

	void Update () {
		if (CoroutineRecaller == true){
			vehicleflag = true;
			currentTimeStep = startTimeStep;
			StartCoroutine(CreateVehicleCoroutine());
			CoroutineRecaller = false;
		}
			
	}

	IEnumerator CreateVehicleCoroutine(){

			while (vehicleflag) {

				currentTimeStep = Mathf.MoveTowards (
				currentTimeStep, 
				endTimeStep, 
				currentTimeStep * Mathf.Abs (endTimeStep - startTimeStep) / totalTime);


				float time = currentTimeStep;
				time += Random.Range (-timeStepVariation, timeStepVariation) / 2;
				time = Mathf.Clamp (time, 0, time);

				//Debug.Log(string.Format("{0}s -> {1}s", currentTimeStep, time));

				yield return new WaitForSeconds (time);
				Vehicle newVehicle = (Vehicle)Instantiate (vehiclePrefab, Game.Instance.enter.position, Game.Instance.enter.rotation);
				newVehicle.transform.SetParent (this.transform);
			}

	}

}
