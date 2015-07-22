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

	void Start(){
		//Cursor.SetCursor(cursor, new Vector2(32,32), CursorMode.Auto);
	}

}
