using UnityEngine;
using System.Collections;

public class AnimationDog : MonoBehaviour {
	public Animator dogAnimator;

	// Use this for initialization
	void Start () {
		dogAnimator = GetComponent<Animator>();
		//dogAnimator.SetBool("Walking", true);
	}
	
	// Update is called once per frame
	void Update () {//walk

	}

	public void walkDog(){
		dogAnimator.SetBool("Walking", true);

	}
	public void DontwalkDog(){
		dogAnimator.SetBool("Walking", false);
		
	}
}
