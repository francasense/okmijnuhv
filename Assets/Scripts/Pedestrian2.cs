using UnityEngine;
using System.Collections;

public class Pedestrian2 : MonoBehaviour, ICartHandler {

	public Cart cart;
	public Vehicle vehicle;

	public Cart currentCart {get;set;}

	public Character character;
	public GameObject quardaChuva;
	public GameObject cachecol;

	public bool chovendo;
	public bool nevando;


	void Start () {
		quardaChuva.SetActive(false);
		cachecol.SetActive(false);

		UpdateDestination();
		StartCoroutine(CheckDestination());

		character.walk = true;
		character.cart = false;

		chovendo = LevelControl.Instance.chovendoFase;
		nevando = LevelControl.Instance.cachecolFase;

		StartCoroutine(VerificarChuva());
		StartCoroutine(VerificarNeve());


	}

	void UpdateDestination(){
		if(cart == null){
			//vai pro mercado
			this.GetComponent<NavMeshAgent>().destination = Game.Instance.market.position + Game.Instance.market.right * Random.Range(-5f,5f);
		}else{
			//vai pro carro
			this.GetComponent<NavMeshAgent>().destination = vehicle.transform.position - vehicle.transform.forward;
		}
	}

	

	IEnumerator CheckDestination(){
		while(true){
			yield return new WaitForEndOfFrame();
			
			var agent = this.GetComponent<NavMeshAgent>();

			if(agent.hasPath && agent.remainingDistance < 2f){
				if(cart == null){
					//chegou no mercado
					//Debug.Log("chegou no mercado");
					var pos = this.transform.position + this.transform.forward;
					var rot = this.transform.rotation;
					cart = (Cart)Instantiate(Game.Instance.cartManager.cartPrefab, pos, rot);
					cart.transform.SetParent(Game.Instance.cartManager.transform);
					cart.AttachTo(this);
					cart.stuff.gameObject.SetActive(true);
					character.cart = true;
					//this.GetComponent<NavMeshAgent>().radius = 1.5f;
					//this.GetComponent<NavMeshAgent>().ResetPath();
					cart.GetComponent<NavMeshObstacle>().enabled = false;
				}else{
					//chegou no carro de volta
					vehicle.ChangeToExit();
					cart.DetachFrom();
					cart.GetComponent<NavMeshObstacle>().enabled = true;
					cart.stuff.gameObject.SetActive(false);
					//Destroy(cart.gameObject);
					Destroy(this.gameObject);
				}
				yield return new WaitForEndOfFrame();
				UpdateDestination();
				yield return new WaitForEndOfFrame();
			}

			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator VerificarChuva(){
		yield return new WaitForSeconds(0.2f);
		if(chovendo){
			quardaChuva.SetActive(true);
		}else{
			quardaChuva.SetActive(false);
		}
	}
	IEnumerator VerificarNeve(){
		yield return new WaitForSeconds(0.2f);
		if(nevando){
			cachecol.SetActive(true);
		}else{
			cachecol.SetActive(false);
		}
	}
}
