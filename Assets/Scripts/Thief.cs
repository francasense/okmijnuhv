using UnityEngine;
using System.Collections;

public class Thief : MonoBehaviour, ICartHandler {
	
	
	private static Helper instance;
	public static Helper Instance{get{return instance == null ? instance = FindObjectOfType<Helper>() : instance;}}
	public Cart cart;
	private GameObject viatura;
	public GameObject ajudanteSimples;
	public Cart currentCart {get;set;}
	public Character1 character;
	public bool endService = false;
	public GameObject[] vehicles;
	public GameObject[] depo;
	public bool Roubando;
	public bool Detido;
	//MOVIMENTAÇAO INDEPENDENTE DE NAVMESH
	public float speed;
	public float turnSpeed = 100;
	public float stopDistance = 0.5f;
	[HideInInspector]
	public Vector3 destination;

	void Start () {
		//StartCoroutine(destroi(25f));

		this.viatura = GameObject.Find ("PoliceCar");
		character.walk = true;
		character.cart = false;
	}
	IEnumerator destroi(float time){

		yield return new WaitForSeconds (time);
			destruir();
	}
	void destruir(){

		//Debug.Log("destruir");

		if ( this.character.cart == false) {
			Debug.Log("terminou serviço");
			endService = true;

		}else
		{
			StartCoroutine(destroi(1f));
		}

	}
	void Update(){
		UpdateDestination();
		
		character.cart = currentCart != null;
	}

	//MOVIMENTAÇAO INDEPENDENTE DE NAVMESH
	void FixedUpdate () {
		
		var dir = destination-this.transform.position;
		var dirn = dir.normalized;
		
		var rb = GetComponent<Rigidbody>();
		
		if(dir.magnitude > stopDistance){
			this.character.walk = true;
			
			//moving
			rb.velocity = dirn * speed;
			
			//turn
			float angle = Vector3.Angle(this.transform.forward,dirn);
			if(angle > 10f){
				var factor = Mathf.Clamp01(angle / 10f);
				var distRight = Vector3.Distance(this.transform.position + this.transform.right, destination);
				var distLeft = Vector3.Distance(this.transform.position - this.transform.right, destination);
				var turnDir = distLeft < distRight ? -1 : 1;
				var av = rb.angularVelocity;
				av.y = factor * turnDir * turnSpeed;
				rb.angularVelocity = av;
			}else{
				rb.angularVelocity = Vector3.zero;
			}
		}else{
			this.character.walk = false;
			rb.velocity = rb.angularVelocity = Vector3.zero;
		}
	}

	//ATUALIZA O STATUS DELE DE BUSCANDO PARA ESPERANDO E ENTREGANDO(DEPENDENTE DE NAVMESH).
	void UpdateDestination(){
		if (this.Roubando == false && HasVehicle () == true) {
			//rouba um carro
			this.destination = SeekVehicle ().transform.position;
			if( Vector3.Distance(destination, this.transform.position) < 1.5){
			this.Roubando = true;
			}
		} else if (this.Roubando == false && HasVehicle () == false) {
			//espera um carrinho
			this.destination = this.transform.position;
		} else if (this.Roubando == true && Detido == true) {
			this.destination = viatura.transform.position;
		}
	}

	//EXECUTA BUSCA PELO CARRINHO MAIS PROXIMO
	public GameObject SeekVehicle(){
		
		GameObject proximo = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		vehicles = GameObject.FindGameObjectsWithTag ("Vehicle");
		
		
		foreach (GameObject t in vehicles) {
			if(t.GetComponent<Vehicle>().state == Vehicle.State.Parked){
				float dist = Vector3.Distance(t.transform.position, currentPos);
				if (dist < minDist)
				{
					proximo = t;
					minDist = dist;
				}
			}
		}
		return proximo;
	}
	

	//VERIFICA EXISTENCIA DE CARRINHOS DISPONIVEIS
	public bool HasVehicle(){
		int n = 0;
		vehicles = GameObject.FindGameObjectsWithTag ("Vehicle");
		foreach (GameObject t in vehicles) {
			if(t.GetComponent<Vehicle>().state == Vehicle.State.Parked)
				n++;
		}
		if (n > 0) {
			return true;
		} else
			return false;
	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "PoliceCar") {
			Destroy(this.gameObject);
		}
		if (col.gameObject.name == "Police") {
			this.Detido = true;
		}
	}
}
