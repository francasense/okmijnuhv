using UnityEngine;
using System.Collections;

public class EnableDesableCamera : MonoBehaviour {

	// Use this for initialization
	public Camera camera;
	public MoveCamera moveCamera;
	public Transform pontoInicial;
	public Transform target;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Player")){
			Vector3 startingPos = pontoInicial.position;

			transform.position = Vector3.Lerp(startingPos, target.position, 5f);
			//yield return 0;
			
			//camera.gameObject.GetComponent<MoveCamera>().enabled = true;
			moveCamera.smooth = 3.0f;
			//camera.gameObject.GetComponent<BoxCollider>().isTrigger = false;
			
			//camera.main.gameObject.GetComponent(MouseOrbit).enabled = true ;
			
			
		}else{
			moveCamera.smooth = 1.5f;

		}
	}
}
