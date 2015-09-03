using UnityEngine;
using System.Collections;

public class DodWalk : MonoBehaviour {
	public Transform target;
	NavMeshAgent agent;
	public AnimationDog animationDog;
	public bool teste;
	public GameObject otherObject;
	public GameObject otherObject2;
	public GameObject desabilitarSequir;
	public bool testTarget;
	public bool pau;
	public GameObject painelDog;
	public lancarPau lancarPaus;
	public bool PaunaMao;
	public bool PaunaMaos;


	// Use this for initialization
	void Start () {
		PaunaMao = false;
		PaunaMaos = false;
		painelDog.SetActive(false);
		pau = false;
		testTarget = true;
		teste = false;
		agent = GetComponent<NavMeshAgent>();
		//otherObject.GetComponent<>("targetmove").enabled = false;
		otherObject = GameObject.Find("dogMarker");
		otherObject2 = GameObject.Find("DogTarget");
		desabilitarSequir.SetActive(true);

		//otherObject.GetComponent<targetMove>().enabled = true;


	}
	
	// Update is called once per frame
	void Update () {
		PaunaMao = PaunaMaos;
		agent.SetDestination (target.position);
	
	}
	void OnTriggerEnter(Collider theCollision)
	{

		
		if (theCollision.tag == "Dog"){
			animationDog.DontwalkDog();
			Debug.Log("Cachorro colidiu!");

		}
		if (theCollision.tag == "mao"){
				lancarPaus.chamouCachorroteste = true;

		}

		if (theCollision.tag == "TargetDogTurtorial"){

			if(pau){
			testTarget = false;
			}else{
				painelDog.SetActive(true);
			}
		}
		if (theCollision.tag == "DesabilitarDog"){

				painelDog.SetActive(false);
				

		}
		
	}

	public void fecharDogTurtorial(){
		painelDog.SetActive(false);

	}

	void OnTriggerExit(Collider theCollision)
	{
		
		if (theCollision.tag == "Dog"){
			animationDog.walkDog();

		}

		
	}

	//animator.SetBool("walking", walk);

}
