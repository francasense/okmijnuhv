using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour, ICartHandler {
	
	
	private static Helper instance;
	public static Helper Instance{get{return instance == null ? instance = FindObjectOfType<Helper>() : instance;}}
	
	public Cart cart;
	
	private GameObject deposito;
	public GameObject ajudanteSimples;
	
	public Cart currentCart {get;set;}
	
	public Character1 character;

	public bool endService = false;

	public GameObject[] carts;
	
	void Start () {
		StartCoroutine(destroi(25f));

		deposito = GameObject.Find ("DeployZone");
		
		
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
	
	//ATUALIZA O STATUS DELE DE BUSCANDO PARA ESPERANDO E ENTREGANDO.
	void UpdateDestination(){
		if (character.cart == false && HasCart () == true) {
			//busca um carrinho
			this.GetComponent<NavMeshAgent> ().destination = SeekCart ().transform.position;
			this.character.walk = true;
		} else if (character.cart == false && HasCart () == false) {
			//espera um carrinho
			this.GetComponent<NavMeshAgent> ().destination = this.transform.position;
			this.character.walk = false;
			if (endService) {
				this.character.walk = true;
				this.GetComponent<NavMeshAgent> ().destination = GameObject.Find ("SpawMather").transform.position;
				if( Vector3.Distance(this.transform.position, GameObject.Find ("SpawMather").transform.position) < 1)
					Destroy(this.gameObject);
			}
		} else if (character.cart == true) {
			//entrega o carrinho
			this.GetComponent<NavMeshAgent> ().destination = deposito.transform.position;
			this.character.walk = true;
		}
	}
	
	//EXECUTA BUSCA PELO CARRINHO MAIS PROXIMO
	public GameObject SeekCart(){
		
		GameObject proximo = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		carts = GameObject.FindGameObjectsWithTag ("Cart");
		
		
		foreach (GameObject t in carts) {
			if(t.GetComponent<Cart>().colectable == true && t.GetComponent<Cart>().empty == true){
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
	public bool HasCart(){
		int n = 0;
		carts = GameObject.FindGameObjectsWithTag ("Cart");
		foreach (GameObject t in carts) {
			if(t.GetComponent<Cart>().colectable == true && t.GetComponent<Cart>().empty == true)
				n++;
		}
		if (n > 0) {
			return true;
		} else
			return false;
		
	}
	
	
	
}
