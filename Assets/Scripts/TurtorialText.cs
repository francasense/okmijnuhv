using UnityEngine;
using System.Collections;

public class TurtorialText : MonoBehaviour {


	public int DayText;
	public string turtorial;
	// Use this for initialization
	void Start(){
		//Cursor.SetCursor(cursor, new Vector2(32,32), CursorMode.Auto);

		
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public void TextDay(int DayText){

		switch (DayText)
		{
		case 1:
			turtorial = "Bem vindo ao seu primeiro dia";
			break;
		case 2:
			turtorial = "";
			break;
		case 3:
			turtorial = "";
			break;
		case 4:
			turtorial = "";
			break;
		case 5:
			turtorial = "";
			break;
		case 6:
			turtorial = "";
			break;
		case 7:
			turtorial = "";
			break;
		case 8:
			turtorial = "";
			break;
		case 9:
			turtorial = "";
			break;
		case 10:
			turtorial = "";
			break;
		case 11:
			turtorial = "";
			break;
		case 12:
			turtorial = "";
			break;
		default:
			//StartCoroutine("Day1");
			break;
		}
	}

}
