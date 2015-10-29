using UnityEngine;
using System.Collections;

public class Police : MonoBehaviour, ICartHandler {
	
	
	private static Helper instance;
	public static Helper Instance{get{return instance == null ? instance = FindObjectOfType<Helper>() : instance;}}
	public Cart cart;
	private GameObject deposito1;
	private GameObject deposito2;
	public GameObject ajudanteSimples;
	public Cart currentCart {get;set;}
	public Character1 character;
	public bool endService = false;
	public GameObject[] thieves;
	public GameObject[] depo;
	public bool Detendo;
	//MOVIMENTAÇAO INDEPENDENTE DE NAVMESH
	public float speed;
	public float turnSpeed = 100;
	public float stopDistance = 0.5f;
	[HideInInspector]
	public Vector3 destination;
	
	void Start () {
		//StartCoroutine(destroi(25f));
		
		
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

		//Verifica se tem obstaculo a frente e empurra ele para o lado caso exista.
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		//Debug.DrawRay (transform.position, fwd);
		if (Physics.Raycast(transform.position, fwd,out hit, 2)) {
			if(hit.transform.gameObject.CompareTag("Vehicle")){
				this.transform.Translate(Vector3.right * Time.deltaTime * 10);
			}
		}
		
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
		if (this.Detendo == false && HasThief () == true) {
			//Aborda um Ladrao
			this.destination = SeekThief ().transform.position;
		} else if (this.Detendo == false && HasThief () == false) {
			//Espera um Ladrao
			this.destination = this.transform.position;
		}
	}
	
	//EXECUTA BUSCA PELO CARRINHO MAIS PROXIMO
	public GameObject SeekThief(){
		
		GameObject proximo = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		thieves = GameObject.FindGameObjectsWithTag ("Thief");

		
		foreach (GameObject t in thieves) {
			if(t.GetComponent<Thief>().Roubando = true){
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
	public bool HasThief(){
		int n = 0;
		thieves = GameObject.FindGameObjectsWithTag ("Thief");
		foreach (GameObject t in thieves) {
			if(t.GetComponent<Thief>().Roubando == true)
				n++;
		}
		if (n > 0) {
			return true;
		} else
			return false;
	}
	
}
