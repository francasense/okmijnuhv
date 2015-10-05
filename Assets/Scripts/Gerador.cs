using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gerador : MonoBehaviour {

	public int size;
	public List<Transform> blocos;
	public Transform prefabGrama;
	public Transform prefabTerra;
	public Transform prefabNeve;
	public Transform prefabAgua;
	public float height;
	public float width;
	public float neveY;
	public float terraY;
	public float aguaY;

	public Transform agua;

	void Start () {

	}

	public void Remake(){
		Clear();
		Make();
	}

	void Clear(){
		if(blocos != null){
			foreach(Transform bloco in blocos.ToArray()){
				DestroyImmediate(bloco.gameObject);
			}
			blocos.Clear();
		}
		if(agua != null){
			DestroyImmediate(agua.gameObject);
		}
	}


	void Make(){
		blocos = new List<Transform>();
		for(int i = 0; i < size; i++){
			for(int j = 0; j < size; j++){
				float y = 
					Mathf.PerlinNoise(
						(float)i/size * width,
						(float)j/size * width);
				
				Transform bloco;
				if(y >= neveY)
					bloco = (Transform) Instantiate(prefabNeve);
				else if(y <= terraY)
					bloco = (Transform) Instantiate(prefabTerra);
				else
					bloco = (Transform) Instantiate(prefabGrama);
				
				bloco.SetParent(this.transform);
				bloco.position = new Vector3(i,y*height,j);
				blocos.Add(bloco);
			}
		}

		agua = (Transform)Instantiate(prefabAgua);
		agua.SetParent(this.transform);
		agua.localPosition = new Vector3(size/2f,aguaY,size/2f);
		agua.localScale = new Vector3(size,size,1);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
