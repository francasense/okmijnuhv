using UnityEngine;
using System.Collections;

public class CartMather : MonoBehaviour {
	public Mather mather;
	public GameObject ativar;
	
	void Start () {

	}

	//public void destroi(){
		//Destroy(gameObject);
		//ativar.SetActive(false);

//	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Matherbaby")){
			//mather.voltarMather();
			//Mather.Instance.t = false;
			Mather.Instance.Matherbaby.SetBool("voltando", true);
			Destroy(gameObject);

			//ativar.SetActive(false);
			GerenciarExtras.Instance.cartBaby.SetActive(false);
			GerenciarExtras.Instance.diamante.SetActive(true);
			TimeDog.Instance.valendofalso();

		}
	}

}
