using UnityEngine;
using System.Collections;

public class Ajudante : MonoBehaviour {
	
	NavMeshAgent agent;
	public Transform target;
	
	//	Nav nav;
	
	
	void Start ()
	{	
		
		agent = GetComponent<NavMeshAgent>();
		//nav = GameObject.FindObjectOfType<Nav> ();
	}
	
	
	void Update () {
		//if (nav.limite2 < nav.limite) {
		
		//verificardistancia(nav.limite);
		verificardistancia(10);
		
		//}
		
		//	verificardistancia2(nav.limite2);
		
	}
	public void verificardistancia(float j){
		
		if (Vector3.Distance (target.position, this.transform.position) < j) {
			agent.SetDestination (target.position);
		}
		
	}
	/*
	public void verificardistancia2(float j){
		
		if (Vector3.Distance (target2.position, this.transform.position) < j) {
			agent.SetDestination (target2.position);
		}
		
	}
	*/
	
	
}
