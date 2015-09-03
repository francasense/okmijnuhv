using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Market : MonoBehaviour {

	private static Market instance;
	public static Market Instance{get{return instance == null ? instance = FindObjectOfType<Market>() : instance;}}
	public List<Transform> exits;
	public Cart cartPrefab;
//	public float startTimeStep = 50f;
//	public float endTimeStep = 40;
//	public float totalTime = 120f;//1min
//	float currentTimeStep;
	private int firstTime = 0;
	public float minCartSpeed = 1f;
	public float maxCartSpeed = 5f;
	public int maxFreeCarts;
	public int currentFreeCarts = 0;
	public RectTransform lifeBarContent;
	public GameObject panelFired;
	public UnityEngine.UI.Text textPoints;
	public UnityEngine.UI.Text textRecord;
	public UnityEngine.UI.Text textPointsWin;
	public UnityEngine.UI.Text textRecordWin;
	public GameObject panelTurtorial;
	public GameObject panelEndLevel;
	public bool endLevel;
	public bool LevelCompleted;
	public int pointsperLevel;
	public int numLevel = 0;

	void Start () {
		StartCoroutine(CreateCarCoroutine());
		LevelCompleted = false;
		endLevel = false;
		int teste = PlayerPrefs.GetInt("chave");
		PlayerPrefs.SetInt("chave",teste);
		PlayerPrefs.SetInt("chave",0);
		Debug.Log(PlayerPrefs.GetInt("chave"));
	//	maisUm++;

		//currentTimeStep = startTimeStep;

		if (PlayerPrefs.GetInt("chave") == 0){
			//Debug.Log(PlayerPrefs.GetInt("chave"));
			panelTurtorial.SetActive(true);
		}

	}

	public void fecharPanelTurtorial(){
		panelTurtorial.SetActive(false);
		PlayerPrefs.SetInt("chave", 1); 

		DayManager.Instance.dayflag = true;
		Debug.Log(PlayerPrefs.GetInt("chave"));



	}

	public void LevelFinish(float numero){
		StartCoroutine(LevelFinishEnumertor(numero));
		Debug.Log("levelfinish"+numero);
	}
	IEnumerator LevelFinishEnumertor(float timelevelfinish){
		yield return new WaitForSeconds(timelevelfinish);
		LevelCompleted = true;
	}


	void Update () {
	//	currentTimeStep = Mathf.MoveTowards(
		//	currentTimeStep, endTimeStep, 
		//	Time.deltaTime/(totalTime/Mathf.Abs(endTimeStep-startTimeStep)));

		var sd = lifeBarContent.sizeDelta;
		sd.x = (lifeBarContent.parent as RectTransform).rect.width * ((float)currentFreeCarts/maxFreeCarts);
		lifeBarContent.sizeDelta = sd;

		if(currentFreeCarts == maxFreeCarts){
			//perdeu
			Time.timeScale = 0f;
			panelFired.SetActive(true);
			textPoints.text = "Points: " + Player.Instance.points;
			int record = Mathf.Max(Player.Instance.points,PlayerPrefs.GetInt("Record"));
			PlayerPrefs.SetInt("Record",record);
			textRecord.text = "Record: "+record;
			
		}
				

		if(Player.Instance.points> LevelControl.Instance.pointsperLevel || LevelCompleted){
			//PlayerPrefs.SetInt("openLevel",0);
			//PlayerPrefs.SetInt("openLevel",numLevel);
			Debug.Log("fim");
			panelEndLevel.SetActive(true);
			Player.Instance.inicio = 0f;
			textPointsWin.text = "Points: " + Player.Instance.points;
			int record = Mathf.Max(Player.Instance.points,PlayerPrefs.GetInt("Record"));
			PlayerPrefs.SetInt("Record",record);
			textRecordWin.text = "Record: "+record;
			PlayerPrefs.SetInt("openLevel", numLevel);
			PlayerPrefs.SetInt("cont",1);

		}

	}

	IEnumerator CreateCarCoroutine(){
		yield return new WaitForSeconds(0.2f);

		maxFreeCarts = LevelControl.Instance.LifeBar;
		pointsperLevel = LevelControl.Instance.pointsperLevel;
		yield return new WaitForSeconds(2f);
		numLevel = LevelControl.Instance.openLevel;
		//Debug.Log("valor numLevel - " + numLevel);

		//while(true){



			//yield return new WaitForSeconds(currentTimeStep);
			//Transform exit = exits[Random.Range(0,exits.Count)];
			//Cart newCart = (Cart)Instantiate(cartPrefab, exit.position, exit.rotation);
			//newCart.GetComponent<Rigidbody>().velocity = newCart.transform.forward * Random.Range(minCartSpeed,maxCartSpeed);
		//}
	}
}
