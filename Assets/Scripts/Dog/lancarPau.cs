using UnityEngine;
using System.Collections;

public class lancarPau : MonoBehaviour {

	private static lancarPau instance;
	public static lancarPau Instance{get{return instance == null ? instance = FindObjectOfType<lancarPau>() : instance;}}
	public GameObject lancar;
	public GameObject pau;
	public GameObject marcadoresLancadores;
	public bool testPau;
	public bool testPaus;

	public bool pauResultado;
	public bool Resultado;
	public bool chamouCachorro;
	public bool chamouCachorroteste;



	// Use this for initialization
	void Start () {
		lancar.SetActive(false);
		Resultado = false;
		chamouCachorro = false;
		chamouCachorroteste = false;
	}
	
	// Update is called once per frame
	void Update () {
		testPau = Resultado;
		testPaus = pauResultado;
		chamouCachorro = chamouCachorroteste;
	}

	void OnTriggerEnter(Collider theCollision)
	{
		
		if (theCollision.tag == "cupoDireita"){
			if(chamouCachorro){

			Resultado = true;
			Debug.Log("copidiu pau");
			lancar.SetActive(true);	
			pau.SetActive(false);
			pauResultado = true;
			marcadoresLancadores.SetActive(false);
			GerenciarExtras.Instance.diamante2.SetActive(true);
			}

		}
		if (theCollision.tag == "cupoEsquerda"){
			if(chamouCachorro){

			Resultado = true;
			Debug.Log("copidiu pau");
			lancar.SetActive(true);
			pau.SetActive(false);
			pauResultado = false;
			Destroy(theCollision.gameObject);
			marcadoresLancadores.SetActive(false);
			GerenciarExtras.Instance.diamante2.SetActive(true);
			}

		}

	}
}
