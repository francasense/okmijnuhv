using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Market : MonoBehaviour {

	private static Market instance;
	public static Market Instance{get{return instance == null ? instance = FindObjectOfType<Market>() : instance;}}

	public List<Transform> exits;

	public Cart cartPrefab;

	public float startTimeStep = 5f;
	public float endTimeStep = 1f;
	public float totalTime = 60f;//1min
	float currentTimeStep;

	public float minCartSpeed = 1f;
	public float maxCartSpeed = 5f;

	public int maxFreeCarts = 20;
	public int currentFreeCarts = 0;

	public RectTransform lifeBarContent;
	public GameObject panelFired;
	public UnityEngine.UI.Text textPoints;
	public UnityEngine.UI.Text textRecord;

	void Start () {
		currentTimeStep = startTimeStep;
		//StartCoroutine(CreateCarCoroutine());
	}

	void Update () {
		currentTimeStep = Mathf.MoveTowards(
			currentTimeStep, endTimeStep, 
			Time.deltaTime/(totalTime/Mathf.Abs(endTimeStep-startTimeStep)));

		var sd = lifeBarContent.sizeDelta;
		sd.x = (lifeBarContent.parent as RectTransform).rect.width * ((float)currentFreeCarts/maxFreeCarts);
		lifeBarContent.sizeDelta = sd;

		if(currentFreeCarts == maxFreeCarts){
			//perdeu
			StartCoroutine(gameover());

		}
	}
	IEnumerator gameover(){
			panelFired.SetActive(true);
			textPoints.text = "Points: " + Player.Instance.points;
			int record = Mathf.Max(Player.Instance.points,PlayerPrefs.GetInt("Record"));
			PlayerPrefs.SetInt("Record",record);
			textRecord.text = "Record: "+record;
			yield return new WaitForSeconds(2.0f);
			Time.timeScale = 0f;


	}

	IEnumerator CreateCarCoroutine(){
		while(true){
			yield return new WaitForSeconds(currentTimeStep);
			Transform exit = exits[Random.Range(0,exits.Count)];
			Cart newCart = (Cart)Instantiate(cartPrefab, exit.position, exit.rotation);
			newCart.GetComponent<Rigidbody>().velocity = newCart.transform.forward * Random.Range(minCartSpeed,maxCartSpeed);
		}
	}
}
