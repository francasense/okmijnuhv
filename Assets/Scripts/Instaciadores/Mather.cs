using UnityEngine;
using System.Collections;

public class Mather : MonoBehaviour {
	private static Mather instance;
	public static Mather Instance{get{return instance == null ? instance = FindObjectOfType<Mather>() : instance;}}
	
	public Animator Matherbaby;
	public bool carrinho = false, t = true;
	public CartMather cartMather;

	void Start () {
		StartCoroutine(animaMather());
	}
	
	//public void Update(){
	//	carrinho = t;
	//}
	
	public IEnumerator animaMather(){
		//yield return new WaitForSeconds (3);
		//yield return new WaitForSeconds (2.45f);
		
		Matherbaby.SetBool("Andar", true);
		yield return new WaitForSeconds (2.45f);
		Matherbaby.SetBool("Andar", false);
		yield return new WaitForSeconds (0.1f);
		GerenciarExtras.Instance.cartBaby.SetActive(true);
		//yield return new WaitForSeconds (10.1f);
		//Debug.Log(carrinho);
		/*
		if (carrinho){
			SpawMather.Instance.destroiCarrinho();
			Matherbaby.SetBool("voltando", true);

			SpawMather.Instance.Spawn();

		}else{
			SpawMather.Instance.Spawn();

		}
		*/
	}
	
	
	
	
	
}
