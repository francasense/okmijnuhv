using UnityEngine;
using System.Collections;

public class DogScript : MonoBehaviour {
//	public Transform target;
	NavMeshAgent agent;
	public AnimationDog animationDog;
//	public bool teste;
//	public GameObject otherObject;
//	public GameObject otherObject2;
//	public GameObject desabilitarSequir;
//	public bool testTarget;
//	public bool pau;
//	public GameObject painelDog;
//	public lancarPau lancarPaus;
	public bool PaunaMao;
//	public bool PaunaMaos;
	public GameObject[] pedestrians;

	// Use this for initialization
	void Start () {
		PaunaMao = false;
//		PaunaMaos = false;
//		painelDog.SetActive(false);
//		pau = false;
//		testTarget = true;
//		teste = false;
//		agent = GetComponent<NavMeshAgent>();
//		//otherObject.GetComponent<>("targetmove").enabled = false;
//		otherObject = GameObject.Find("dogMarker");
//		otherObject2 = GameObject.Find("DogTarget");
//		desabilitarSequir.SetActive(true);

		//otherObject.GetComponent<targetMove>().enabled = true;


	}
	
	// Update is called once per frame
	void Update () {
		//PaunaMao = PaunaMaos;
		//agent.SetDestination (target.position);
		if (Vector3.Distance (this.transform.position, GameObject.Find ("Player").transform.position) < 1f) {
			PaunaMao = true;
			TimeDog.Instance.valendofalso();
		}

		UpdateDestination ();
	}

	void UpdateDestination(){
		if(PaunaMao){
			this.GetComponent<NavMeshAgent> ().destination = GameObject.Find ("SpawnDog").transform.position;
			animationDog.walkDog();
			if( Vector3.Distance(this.transform.position, GameObject.Find ("SpawnDog").transform.position) < 1)
				Destroy(this.gameObject);
		}else if (HasPedestrians () == true) {
			//busca um cliente
			this.GetComponent<NavMeshAgent> ().destination = SeekPedestrian().transform.position;
			animationDog.walkDog();
		} else if (HasPedestrians () == false) {
			//espera um cliente
			this.GetComponent<NavMeshAgent> ().destination = this.transform.position;
			animationDog.DontwalkDog();
		} 
	}


//	void OnTriggerEnter(Collider theCollision)
//	{
//
//		
//		if (theCollision.tag == "Dog"){
//			animationDog.DontwalkDog();
//			Debug.Log("Cachorro colidiu!");
//
//		}
//		if (theCollision.tag == "mao"){
//				lancarPaus.chamouCachorroteste = true;
//
//		}
//
//		if (theCollision.tag == "TargetDogTurtorial"){
//
//			if(pau){
//			testTarget = false;
//			}else{
//				painelDog.SetActive(true);
//			}
//		}
//		if (theCollision.tag == "DesabilitarDog"){
//
//				painelDog.SetActive(false);
//				
//
//		}
//		
//	}
//
//	public void fecharDogTurtorial(){
//		painelDog.SetActive(false);
//
//	}
//
//	void OnTriggerExit(Collider theCollision)
//	{
//		
//		if (theCollision.tag == "Dog"){
//			animationDog.walkDog();
//
//		}
//
//		
//	}

	public GameObject SeekPedestrian(){
		
		GameObject proximo = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		pedestrians = GameObject.FindGameObjectsWithTag ("Pedestrian");
		
		
		foreach (GameObject t in pedestrians) {

				float dist = Vector3.Distance(t.transform.position, currentPos);
				if (dist < minDist)
				{
					proximo = t;
					minDist = dist;
				}

		}
		return proximo;
	}

	public bool HasPedestrians(){
		int n = 0;
		pedestrians = GameObject.FindGameObjectsWithTag ("Pedestrian");
		foreach (GameObject t in pedestrians) {
				n++;
		}
		if (n > 0) {
			return true;
		} else
			return false;
	}

}
