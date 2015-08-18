using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private static Game instance;
	public static Game Instance{ get{ return instance == null ? (instance = FindObjectOfType<Game>()) : instance; } }

	public VehicleManager vehicleManager;
	public VagasManager vagasManager;
	public PedestrianManager pedestrianManager;
	public CartManager cartManager;

	public Transform enter;
	public Transform exit;
	public Transform market;

	public Texture2D cursor;

	//Eventos:
	public DayManager dayManager;
	public SpawnHelper spawnHelper;
	public SpawnMother spawnMother;
	public SpawnDog spawnDog;
	public SpawnThief spawnThief;
	public int day;

	void Start(){
		//Cursor.SetCursor(cursor, new Vector2(32,32), CursorMode.Auto);
		switch (day)
		{
		case 1:
			StartCoroutine("Day1");
			break;
		case 2:
			StartCoroutine("Day2");
			break;
		case 3:
			StartCoroutine("Day3");
			break;
		case 4:
			StartCoroutine("Day4");
			break;
		case 5:
			StartCoroutine("Day5");
			break;
		case 6:
			StartCoroutine("Day6");
			break;
		case 7:
			StartCoroutine("Day7");
			break;
		default:
			StartCoroutine("Day1");
			break;
		}
		
	}

	IEnumerator Day1() {
		yield return new WaitForSeconds(10f);
		spawnMother.Spawn ();
		yield return new WaitForSeconds(20f);
		spawnDog.Spawn ();
		//...
		print("Dia 1");
	}

	IEnumerator Day2() {
		yield return new WaitForSeconds(1f);
		print("Dia 2");
	}

	IEnumerator Day3() {
		yield return new WaitForSeconds(1f);
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
}	












