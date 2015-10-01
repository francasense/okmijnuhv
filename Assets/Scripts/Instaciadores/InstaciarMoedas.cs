using UnityEngine;
using System.Collections;

public class InstaciarMoedas : MonoBehaviour {

	private static InstaciarMoedas instance;
	public static InstaciarMoedas Instance{get{return instance == null ? instance = FindObjectOfType<InstaciarMoedas>() : instance;}}

	public GameObject[] objetos;
	private bool isEsquerda = true;
	public float velocidade = 5f;
	public float mxDelay;
	
	public float instanciadorTime = 5f;
	public float instaciandorDelay = 3f;
	
	private float timeMove = 0f;
	public int valorMinimoRandom = 0, teste = 0;
	
	
	// Use this for initialization
	void Start () {
		teste = 0;
		//InvokeRepeating ("Spawn", instanciadorTime, instaciandorDelay);
		
	}
	
	// Update is called once per frame
	void Update () {
		Moved();


	}
	
	public void Spawn(int teste)
	{
		if (teste==1){
		int index = Random.Range (valorMinimoRandom, objetos.Length);
		Instantiate (objetos [index], transform.position, objetos [index].transform.rotation);
		}
	}
	
	void Moved()
	{
		timeMove += Time.deltaTime;
		
		if (timeMove <= mxDelay) {
			
			
			if (isEsquerda) {
				
				transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
				
			} else {
				
				transform.Translate (-Vector2.right * velocidade * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);
				
				
			}
		} else {
			
			isEsquerda = !isEsquerda;
			timeMove = 0;
			
		}
		
	}
}
