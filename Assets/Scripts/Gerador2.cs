using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Gerador2 : MonoBehaviour {
	
	public int size;
	public List<Transform> blocos;
	public Transform basemaior;
	public Transform basemeio;
	public Transform basemenor;
	public float height;
	public float width;
	public float neveY;
	public float terraY;
	public float aguaY;
	
	public Transform agua;
	
	void Start () {
		
	}
	
	public void Remake(){
		Make();
	}
	

	
	
	void Make(){
		blocos = new List<Transform>();
		for(int i = 0; i < 2; i++){
			for(int j = 0; j < 2; j++){
				float y = 
					Mathf.PerlinNoise(
						(float)i/size * width,
						(float)j/size * width);
				
				Transform bloco;
				if(y >= neveY)
					bloco = (Transform) Instantiate(basemaior);
				else if(y <= terraY)
					bloco = (Transform) Instantiate(basemeio);
				else
					bloco = (Transform) Instantiate(basemenor);
				
				bloco.SetParent(this.transform);
				bloco.position = new Vector3(i,y*height,j);
				blocos.Add(bloco);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}