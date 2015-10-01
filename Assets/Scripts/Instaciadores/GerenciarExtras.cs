using UnityEngine;
using System.Collections;

public class GerenciarExtras : MonoBehaviour {
	
	private static GerenciarExtras instance;
	public static GerenciarExtras Instance{get{return instance == null ? instance = FindObjectOfType<GerenciarExtras>() : instance;}}
	private int value;
	public GameObject ajudanteSimples;
	//public int contador, pointsCois=0, v1,v2;
	public GameObject ButtonHelper;
	public GameObject ButtonHelperOFF;
	public GameObject ButtonSuperOFF;

	public GameObject noCoin;
	public GameObject botaoSpeed;
	public GameObject super;
	public GameObject cartBaby;
	public GameObject diamante;
	public GameObject diamante2;
	public float tempoCachorro;

	//public GameObject cachorro;
	//public GameObject pau;

	public Player player;
	public int point;

	//public InstaciadorMoedas instaciadorMoedas;
	//[HideInInspector]
	//public int InsMoedas;
	public UnityEngine.UI.Text textCoin;
	int turno=0;
	private int valorPeriodo=0;

	void Start () {
		//point = 0;

		point = PlayerPrefs.GetInt("moedas");

		textCoin.text = point.ToString();

//		StartCoroutine(cachorrocorrotina());
//		pau.SetActive(false);
//		cachorro.SetActive(false);
		diamante.SetActive(false);
		diamante2.SetActive(false);

		cartBaby.SetActive(false);
		Time.timeScale = 1f;
		//InsMoedas = 0;
		ajudanteSimples.SetActive(false);
		ButtonHelper.SetActive(false);
		ButtonHelperOFF.SetActive(true);
		noCoin.SetActive(false);
		botaoSpeed.SetActive(false);
		ButtonSuperOFF.SetActive(true);
		super.SetActive(false);
	}
	public void chamaNoCoin(){
		StartCoroutine(Coin());
	}

	public IEnumerator Coin(){

		yield return null;

		noCoin.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		noCoin.SetActive(false);

	}

	
	public void chamarAjudante(){
		ajudanteSimples.SetActive(true);
		ButtonHelper.SetActive(false);
		//ButtonHelper.SetActive(false);
		ButtonHelperOFF.SetActive(true);

		AddCoin(2);


	}


	
	public void AddCoin(int pointsCois){
		point++;

		//PlayerPrefs.SetInt("points",PlayerPrefs.GetInt("points")+1);

		if (pointsCois == 2){
			point = point-3;
			ButtonHelper.SetActive(false);
			ButtonHelperOFF.SetActive(true);


		}
		if (pointsCois == 3){
			point = point-5;
			botaoSpeed.SetActive(false);
			ButtonSuperOFF.SetActive(true);


			
			
		}

		//point++;
		textCoin.text = point.ToString();
		Debug.Log("valor points"+point);
	
		//point++;
		//textCoin.text = PlayerPrefs.GetInt("points").ToString();
		//Debug.Log("valor points"+PlayerPrefs.GetInt("points"));
		if (point == 3){
			ButtonHelper.SetActive(true);
			ButtonHelperOFF.SetActive(false);

		}

		if (point == 5){
			ButtonSuperOFF.SetActive(false);
			botaoSpeed.SetActive(true);

			
		}


	}

//	IEnumerator cachorrocorrotina(){
//			yield return new WaitForSeconds(tempoCachorro);
//		cachorro.SetActive(true);
//		pau.SetActive(true);
//
//
//	}
	



	

}



