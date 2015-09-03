using UnityEngine;
using System.Collections;
	
public class MenuLevelControl : MonoBehaviour {
		
		public GameObject btlevel2;
		public GameObject btlevel3;
		public GameObject btlevel4;
		/*
	public GameObject btlevel5;
	public GameObject btlevel6;
	public GameObject btlevel7;
	public GameObject btlevel8;
	public GameObject btlevel9;
	public GameObject btlevel10;
	public GameObject btlevel11;
	public GameObject btlevel12;
	*/
		
		// Use this for initialization
		void Start () {
			btlevel2.SetActive(true);
			btlevel3.SetActive(true);
			btlevel4.SetActive(true);
			/*
		btlevel5.SetActive(true);
		btlevel6.SetActive(true);
		btlevel7.SetActive(true);
		btlevel8.SetActive(true);
		btlevel9.SetActive(true);
		btlevel10.SetActive(true);
		btlevel11.SetActive(true);
		btlevel12.SetActive(true);
		*/
			
			openLevel();
			
		}
		
		public void openLevel(){
			Debug.Log(PlayerPrefs.GetInt("openLevel"));
			int openLevel = PlayerPrefs.GetInt("openLevel");
			
			switch (openLevel)
			{
			case 1:
				btlevel2.SetActive(false);
				break;
			case 2:
				btlevel2.SetActive(false);
				btlevel3.SetActive(false);
				break;
			case 3:
				btlevel2.SetActive(false);
				btlevel3.SetActive(false);
				btlevel4.SetActive(false);
				break;
			case 4:
				//btlevel2.SetActive(false);
				//btlevel3.SetActive(false);
			//	btlevel4.SetActive(false);
				//btlevel5.SetActive(false);
				break;
				
			}
		}
		
		
	}