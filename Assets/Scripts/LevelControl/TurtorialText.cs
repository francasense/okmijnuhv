using UnityEngine;
using System.Collections;

public class TurtorialText : MonoBehaviour {
	

	public GameObject dia01_0;
	public GameObject dia01_1;
	public GameObject dia01_2;
	public GameObject dia02_0;
	public GameObject dia03_0;
	public GameObject dia05_0;
	public GameObject dia07_0;






	public int DayText;
	//public string turtorial;
	public UnityEngine.UI.Text textTurtorialDay;
	// Use this for initialization
	void Start(){
		dia01_0.SetActive(false);
		dia01_1.SetActive(false);
		dia01_2.SetActive(false);
		dia02_0.SetActive(false);
		dia03_0.SetActive(false);
		dia05_0.SetActive(false);
		dia07_0.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	public void TextDay(int DayText){
		
		switch (DayText)
		{
		case 1:
			textTurtorialDay.text = "Bem vindo ao uaumart, prove que vc merece esse emprego!";
			dia01_0.SetActive(true);
			dia01_1.SetActive(true);
			dia01_2.SetActive(true);
			break;

		case 2:
			textTurtorialDay.text = "É isso ai! voce completou o primeiro dia. Lembre sempre de colete as suas gorjetas.";
			dia02_0.SetActive(true);
			break;

		case 3:
			textTurtorialDay.text = "Muito bem. Você está ficando rápido, use suas moedas para habilitar a super velocidade.";
			dia03_0.SetActive(true);
			break;

		case 4:
			textTurtorialDay.text = "Gerencie bem suas moedas!";
			break;
		case 5:
			textTurtorialDay.text = "Lembre sempre que precisar vocë pode usar um ajudante. Contrate-o usando suas moedas.";
			dia05_0.SetActive(true);

			break;
		case 6:
			textTurtorialDay.text = "Que dia frio hein. Cuidado com a neve!";
			break;
		case 7:
			textTurtorialDay.text = "Não deixe animais importunarem os clientes";
			dia07_0.SetActive(true);

			break;
		case 8:
			textTurtorialDay.text = "Sua equipe está crescendo. Agora você pode contratar até dois ajudantes";
			break;
		case 9:
			textTurtorialDay.text = "Projeta seu ambiente de trabalho avisando a policia sobre ladroes no estacionamento.";
			break;
		case 10:
			textTurtorialDay.text = "Você não precisa mais de dicas. Se você chegou até aqui agora pode ser virar sozinho.";
			break;
		case 11:
			textTurtorialDay.text = "dia 11";
			break;
		case 12:
			textTurtorialDay.text = "dia 12";
			break;
		default:
			//StartCoroutine("Day1");
			break;
		}
	}

	public void padrao(){
		dia01_0.SetActive(false);
		dia01_1.SetActive(false);
		dia01_2.SetActive(false);
		dia02_0.SetActive(false);
		dia03_0.SetActive(false);
		dia05_0.SetActive(false);
		dia07_0.SetActive(false);

	}


}
