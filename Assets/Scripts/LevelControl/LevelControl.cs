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
	public int openLevel = 0;
	
	public bool level01;
	public bool level02;
	public bool level03;
	public bool level04;
	public bool level05;
	public bool level06;
	public bool level07;
	public bool level08;
	public bool level09;
	public bool level010;
	public bool level011;
	public bool level012;
	public GameObject capa;
	public GameObject chuva;
	public GameObject neve;
	public GameObject cachecol;


	public bool chovendoFase;
	public bool cachecolFase;


	
	
	//public float dificuldade;
	
	void Start(){
		neve.SetActive(false);
		cachecol.SetActive(false);
		chovendoFase = false;
		cachecolFase = false;

		chuva.SetActive(false);
		capa.SetActive(false);
		level01 = true;
		level02 = true;
		level03 = true;
		level04 = true;
		level05 = true;
		level06 = true;
		level07 = true;
		level08 = true;
		level09 = true;
		level010 = true;
		level011 = true;
		level012 = true;
		
		
		qualLevel = PlayerPrefs.GetInt("level");
		
		sorteio();
		
		//Cursor.SetCursor(cursor, new Vector2(32,32), CursorMode.Auto);
		switch (qualLevel)
		{
		case 1:
			cachecolFase = true;
			neve.SetActive(true);
			cachecol.SetActive(true);
			StartCoroutine(Day1());
		

			break;

		case 2:
			capa.SetActive(true);
			chuva.SetActive(true);
			chovendoFase = true;

			StartCoroutine(Day2());
			//level02 = false;
			break;
		case 3:
			StartCoroutine(Day3());
			//level03 = false;
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



		int num_dia = 1;
		
		yield return null;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday = 1;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 14f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 5f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 110f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		
		print("Dia 1");
		if((PlayerPrefs.GetInt("openLevel"))>= 0 && (PlayerPrefs.GetInt("openLevel"))<2){
			openLevel = num_dia;
		}
		//int openlevel = PlayerPrefs.GetInt("openLevel");
		
		
	}
	
	IEnumerator Day2() {
		int num_dia = 2;
		
		yield return null;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday = num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level02){
			openLevel = num_dia;
		}
		
		//elementos extras abaixo ###################################################
		print("Dia 2");
		
		
	}
	
	IEnumerator Day3() {
		int num_dia = 3;
		
		yield return null;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday = num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		
		//elementos extras abaixo ###################################################
		yield return new WaitForSeconds(sorteado);
		spawnMother.Spawn ();
		print("Dia 3");
		
	}
	
	IEnumerator Day4() {
		yield return null;
		int num_dia = 4;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		
		//elementos extras abaixo ###################################################
		print("Dia 4");
	}
	
	IEnumerator Day5() {
		yield return null;
		int num_dia = 5;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}

		print("Dia 5");
	}
	
	IEnumerator Day6() {
		yield return null;
		int num_dia = 6;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 6");
	}
	
	IEnumerator Day7() {
		yield return null;
		int num_dia = 7;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		
		//elementos extras abaixo ###################################################
		yield return new WaitForSeconds(sorteado);
		spawnDog.Spawn ();
		print("Dia 7");
	}
	
	IEnumerator Day8() {
		yield return null;
		int num_dia = 8;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 8");
	}
	
	IEnumerator Day9() {
		yield return null;
		int num_dia = 9;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 9");
	}
	
	IEnumerator Day10() {
		yield return null;
		int num_dia = 10;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 10");
	}
	
	IEnumerator Day11() {
		yield return null;
		int num_dia = 11;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 11");
	}
	
	IEnumerator Day12() {
		yield return null;
		int num_dia = 12;
		LifeBar = 10;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 1f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
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


