using UnityEngine;
using System.Collections;

public class GerenciarExtras : MonoBehaviour {
	
	private static GerenciarExtras instance;
	public static GerenciarExtras Instance{get{return instance == null ? instance = FindObjectOfType<GerenciarExtras>() : instance;}}
	private int value;
	public GameObject ajudanteSimples;
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
	public Player player;
	public int point;
	public UnityEngine.UI.Text textCoin;
	int turno=0;
	private int valorPeriodo=0;

	void Start () {
		//point = 0;
		point = PlayerPrefs.GetInt("valorMoedas");
		Debug.Log("valor moedas = "+ PlayerPrefs.GetInt("valorMoedas"));

		textCoin.text = point.ToString();
		diamante.SetActive(false);
		diamante2.SetActive(false);
		cartBaby.SetActive(false);
		Time.timeScale = 1f;
		ajudanteSimples.SetActive(false);
		ButtonHelper.SetActive(false);
		ButtonHelperOFF.SetActive(true);
		noCoin.SetActive(false);
		botaoSpeed.SetActive(false);
		ButtonSuperOFF.SetActive(true);
		super.SetActive(false);
		//loadCoin();
	}


	void Update(){

		if (point >=3){
			Debug.Log("point inicial"+ point);

			ButtonHelper.SetActive(true);
			ButtonHelperOFF.SetActive(false);
			
		}
		
		if (point >=3){
			ButtonSuperOFF.SetActive(false);
			botaoSpeed.SetActive(true);
			
		}
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
		PlayerPrefs.SetInt("moedas",point);

		if (pointsCois == 2){
			point = point-4;
			PlayerPrefs.SetInt("moedas",point);

			ButtonHelper.SetActive(false);
			ButtonHelperOFF.SetActive(true);
		}
		if (pointsCois == 3){
			point = point-4;
			PlayerPrefs.SetInt("moedas",point);

			botaoSpeed.SetActive(false);
			ButtonSuperOFF.SetActive(true);	
		}

		PlayerPrefs.SetInt("moedas",point);
		textCoin.text = point.ToString();
		Debug.Log("valor points"+point);
		Debug.Log("valor moedas"+PlayerPrefs.GetInt("moedas"));
		PlayerPrefs.SetInt("valorMoedas",PlayerPrefs.GetInt("moedas"));


		if (point >=3){
			ButtonHelper.SetActive(true);
			ButtonHelperOFF.SetActive(false);
		}

		if (point >=3){
			ButtonSuperOFF.SetActive(false);
			botaoSpeed.SetActive(true);
		}
	}
}



