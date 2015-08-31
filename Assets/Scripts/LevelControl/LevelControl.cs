using UnityEngine;
using System.Collections;


public class LevelControl : MonoBehaviour {
	
	private static LevelControl instance;
	public static LevelControl Instance{ get{ return instance == null ? (instance = FindObjectOfType<LevelControl>()) : instance; } }
	
	public TurtorialText turtorialText;
	public VehicleManager vehicleManager;
	
	private int level = 1;
	public float dayTime1 = 0f;
	public float nightTime1 = 0f;
	public Market market;
	public int dayday;
	
	public float startTimeStep;
	public float endTimeStep;
	public float totalTime;
	public float timeStepVariation;
	
	public SpawnHelper spawnHelper;
	public SpawnMother spawnMother;
	public SpawnDog spawnDog;
	public SpawnThief spawnThief;
	public float sorteado;
	public int qualLevel;
	public int LifeBar;
	public int pointsperLevel;
	// Use this for initialization
	void Start(){
		qualLevel = PlayerPrefs.GetInt("level");
		sorteio();
		
		//Cursor.SetCursor(cursor, new Vector2(32,32), CursorMode.Auto);
		switch (qualLevel)
		{
		case 1:
			StartCoroutine(Day1());
			break;
		case 2:
			StartCoroutine(Day2());
			break;
		case 3:
			StartCoroutine(Day3());
			break;
		case 4:
			StartCoroutine(Day4());
			break;
		case 5:
			StartCoroutine(Day5());
			break;
		case 6:
			StartCoroutine(Day6());
			break;
		case 7:
			StartCoroutine(Day7());
			break;
		case 8:
			StartCoroutine(Day8());
			break;
		case 9:
			StartCoroutine(Day9());
			break;
		case 10:
			StartCoroutine(Day10());
			break;
		case 11:
			StartCoroutine(Day11());
			break;
		case 12:
			StartCoroutine(Day12());
			break;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	
	IEnumerator Day1() {
		yield return null;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =1;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(1); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 70f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		print("Dia 1");
	}
	
	IEnumerator Day2() {
		print(sorteado);
		
		
		yield return null;
		LifeBar = 20;//o quanto a barra de life vai andar
		dayday =2;//numero do dia
		dayTime1 = 40f;// quanto tempo vai passar de dia 
		nightTime1 = 20f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(1); // texto do turtorial cada dia
		startTimeStep = 10f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 50f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel

		//elementos extras abaixo ###################################################
		yield return new WaitForSeconds(sorteado);
		spawnMother.Spawn ();
		print("Dia 2");
	}
	
	IEnumerator Day3() {
		yield return null;
		LifeBar = 20;//o quanto a barra de life vai andar
		dayday =2;//numero do dia
		dayTime1 = 40f;// quanto tempo vai passar de dia 
		nightTime1 = 20f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(1); // texto do turtorial cada dia
		startTimeStep = 10f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 50f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		
		//elementos extras abaixo ###################################################

		yield return new WaitForSeconds(sorteado);
		spawnDog.Spawn ();
		print("Dia 3");
	}
	
	IEnumerator Day4() {
		yield return new WaitForSeconds(1f);
		print("Dia 4");
	}
	
	IEnumerator Day5() {
		yield return new WaitForSeconds(1f);
		print("Dia 5");
	}
	
	IEnumerator Day6() {
		yield return new WaitForSeconds(1f);
		print("Dia 6");
	}
	
	IEnumerator Day7() {
		yield return new WaitForSeconds(1f);
		print("Dia 7");
	}
	
	IEnumerator Day8() {
		yield return new WaitForSeconds(1f);
		print("Dia 8");
	}
	
	IEnumerator Day9() {
		yield return new WaitForSeconds(1f);
		print("Dia 9");
	}
	
	IEnumerator Day10() {
		yield return new WaitForSeconds(1f);
		print("Dia 10");
	}
	
	IEnumerator Day11() {
		yield return new WaitForSeconds(1f);
		print("Dia 11");
	}
	
	IEnumerator Day12() {
		yield return new WaitForSeconds(1f);
		print("Dia 12");
	}
	
	
	
	
	void sorteio(){
		switch (Random.Range(1,5))
		{
		case 1:
			sorteado = 10f;
			break;
		case 2:
			sorteado = 30f;
			break;
		case 3:
			sorteado = 50f;
			break;
		case 4:
			sorteado = 70f;
			break;
		case 5:
			sorteado = 90f;
			break;
		case 6:
			sorteado = 100f;
			break;
			
		}
	}
}


