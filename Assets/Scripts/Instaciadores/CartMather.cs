using UnityEngine;
using System.Collections;

public class CartMather : MonoBehaviour {
	public Mather mather;
	public GameObject ativar;
	public Character character;

	
	void Start () {
		StartCoroutine(retirarCarro());
	}

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

	IEnumerator retirarCarro(){
		yield return new WaitForSeconds(26f);
		Destroy(gameObject);

		Cart.Instance.DetachFrom();
		GetComponent<Cart> ().colectable = false;
		character.cart = false;
		character.walk = false;
	}

}
