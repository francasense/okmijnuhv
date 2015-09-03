using UnityEngine;
using System.Collections;

public class SuperSpeed : MonoBehaviour {
	private static SuperSpeed instance;
	public static SuperSpeed Instance{get{return instance == null ? instance = FindObjectOfType<SuperSpeed>() : instance;}}
	



	void Start () {
	//	botaoSpeed.SetActive(true);

	}


	public IEnumerator superVelocity(){
				yield return null;


		
		Player.Instance.speed=27;
		yield return new WaitForSeconds (4.0f);
		Player.Instance.speed=7;
		
	}

	public void SpawnSpeed(int teste)
	{
		if (teste==1){
			StartCoroutine(superVelocity());
		}
	//	botaoSpeed.SetActive(false);
	}
	
}
