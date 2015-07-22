  
using UnityEngine;

public class SpawMather : MonoBehaviour

{
	private static SpawMather instance;
	public static SpawMather Instance{get{return instance == null ? instance = FindObjectOfType<SpawMather>() : instance;}}
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	//public GameObject carrinho;
	public CartMather cartMather;
	public int numero = 1;
	
	void Start ()
	{
		Spawn();

	}

	public void Spawn ()
	{

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

//	public void destroiCarrinho(){
//		cartMather.destroi();
	//}
}