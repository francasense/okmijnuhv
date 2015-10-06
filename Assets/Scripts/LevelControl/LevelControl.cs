using UnityEngine;
using System.Collections;


public class LevelControl : MonoBehaviour {
	
	private static LevelControl instance;
	public static LevelControl Instance{ get{ return instance == null ? (instance = FindObjectOfType<LevelControl>()) : instance; } }

	public GameObject maquinaQuebrada;
	public GameObject maquinaBoa;

	public TurtorialText turtorialText;
	public VehicleManager vehicleManager;
	public TimeMather timeMather;
	public TimeDog timeDog;
	public GameObject ladrao;
	public GameObject policeCar;
	public Character character;
	private int level = 1;
	public float dayTime1 = 0f;
	public float nightTime1 = 0f;
	public Market market;
	public int dayday;
	public CartStore cartStore;
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
	public GameObject carrinhosCena;
	public bool chovendoFase;
	public bool cachecolFase;
	public bool primeiroDia;
	

	void Start(){
		primeiroDia = false;
		maquinaQuebrada.SetActive(false);
		policeCar.SetActive(false);
		ladrao.SetActive(false);
		carrinhosCena.SetActive(false);
		neve.SetActive(false);
		cachecol.SetActive(false);
		cachecolFase = false;
		chovendoFase = false;
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
		
		switch (qualLevel)
		{
		case 1:
			primeiroDia = true;
			carrinhosCena.SetActive(true);
			StartCoroutine(Day1());
			break;
		case 2:
			policeCar.SetActive(true);
			primeiroDia = true;
			StartCoroutine(Day2());
			break;
		case 3:
			primeiroDia = true;
			StartCoroutine(Day3());
			break;
		case 4:
			primeiroDia = true;
			StartCoroutine(Day4());
			break;
		case 5:
			policeCar.SetActive(true);
			primeiroDia = true;
			StartCoroutine(Day5());
			break;
		case 6:
			primeiroDia = true;
			StartCoroutine(Day6());
			break;
		case 7:
			primeiroDia = true;
			StartCoroutine(Day7());
			break;
		case 8:
			primeiroDia = true;
			StartCoroutine(Day8());
			break;
		case 9:
			primeiroDia = true;
			StartCoroutine(Day9());
			break;
		case 10:
			policeCar.SetActive(true);
			primeiroDia = true;
			StartCoroutine(Day10());
			break;
		case 11:
			primeiroDia = true;
			StartCoroutine(Day11());
			break;
		case 12:
			primeiroDia = true;
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
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday = 1;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 14f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 8f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 110f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel

		print("Dia 1");
		if((PlayerPrefs.GetInt("openLevel"))>= 0 && (PlayerPrefs.GetInt("openLevel"))<2){
			openLevel = num_dia;
		}
	}
	
	IEnumerator Day2() {
		int num_dia = 2;
		
		yield return null;
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday = num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 13f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 7f; //define a quantidade de carrinhos por segundo no final do dia
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
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday = num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 12f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 6f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(1));
	}
	
	IEnumerator Day4() {
		yield return null;
		int num_dia = 4;
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 11f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 5f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		//elementos extras abaixo ###################################################
		print("Dia 4");
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(4));
	}
	
	IEnumerator Day5() {
		yield return null;
		int num_dia = 5;
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 10f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 4f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 5");
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(2));
	}
	
	IEnumerator Day6() {
		yield return null;
		int num_dia = 6;
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 9f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 3f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		print("Dia 6");
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(5));
	}
	
	IEnumerator Day7() {
		yield return null;
		int num_dia = 7;
		LifeBar = 14;//o quanto a barra de life vai andar
		dayday =num_dia;//numero do dia
		dayTime1 = 80f;// quanto tempo vai passar de dia 
		nightTime1 = 40f;// quanto tempo vai passar de noite 
		turtorialText.TextDay(num_dia); // texto do turtorial cada dia
		startTimeStep = 8f; //define a quantidade de carrinhos por segundos no inicio do turno
		endTimeStep = 2f; //define a quantidade de carrinhos por segundo no final do dia
		totalTime = 40f; //quanto tempo vai durar essa transição
		timeStepVariation = 2f; //variaçao para nao parecer exato e ficar um pouco aleatorio
		market.LevelFinish(120f);//quanto tempo vai durar o dia
		pointsperLevel = 16;//pontos por level pra poder passar de nivel
		if(level03){
			openLevel = num_dia;
		}
		//elementos extras abaixo ###################################################
		yield return new WaitForSeconds(sorteado);
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(3));
	}
	
	IEnumerator Day8() {
		yield return null;
		int num_dia = 8;
		LifeBar = 14;//o quanto a barra de life vai andar
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
		// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
		// escolha um dos elementos e passe como parametro a baixo
		StartCoroutine(instaciarExtras(6));
	}
	
	IEnumerator Day9() {
		yield return null;
		int num_dia = 9;
		LifeBar = 14;//o quanto a barra de life vai andar
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
		LifeBar = 14;//o quanto a barra de life vai andar
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
		LifeBar = 14;//o quanto a barra de life vai andar
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
		LifeBar = 14;//o quanto a barra de life vai andar
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
		switch (Random.Range(1,6))
		{
		case 1:
			sorteado = 10f;
			break;
		case 2:
			sorteado = 20f;
			break;
		case 3:
			sorteado = 30f;
			break;
		case 4:
			sorteado = 40f;
			break;
		case 5:
			sorteado = 50f;
			break;
		case 6:
			sorteado = 60f;
			break;
		}
	}
	// 1(mulher) -  2(ladrao) -  3(cachorro) -  4(chuva) - 5(neve) - 6(maquinaQuebrada)
	IEnumerator instaciarExtras(int extra) {

		yield return null;
		switch (extra)
		{
		case 1:
			//chamar a mulher
			yield return new WaitForSeconds(sorteado);
			spawnMother.Spawn ();
			timeMather.chamarRelogio();
			timeDog.chamarRelogio();
			break;
		case 2:
			//chamar o ladrao
			policeCar.SetActive(true);
			yield return new WaitForSeconds(sorteado);
			ladrao.SetActive(true);
			timeDog.chamarRelogio();
			break;
		case 3:
			//chamar o cachorro
			yield return new WaitForSeconds(sorteado);
			spawnDog.Spawn ();
			timeDog.chamarRelogio();
			break;
		case 4:
			//chamar chuva
			chovendoFase = true;
			chuva.SetActive(true);
			capa.SetActive(true);
			break;
		case 5:
			//chamar neve
			cachecolFase = true;
			neve.SetActive(true);
			cachecol.SetActive(true);
			break;
		case 6:
			//chamar maquina quebrada
			maquinaBoa.SetActive(false);
			maquinaQuebrada.SetActive(true);
			break;
		}
	}
}