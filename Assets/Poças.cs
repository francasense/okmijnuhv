using UnityEngine;
using System.Collections;

public class Poças : MonoBehaviour {

		public bool chovendo;       // Reference to the player's heatlh.
		public GameObject poca;                // The enemy prefab to be spawned.
		public float spawnTime = 10f;            // How long between each spawn.
		public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
		
		
		void Start ()
		{
			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		//if(GameObject.Find("LevelControl").GetComponent<LevelControl>().chovendoFase == true || GameObject.Find("LevelControl").GetComponent<LevelControl>().cachecolFase == true)
		
		}

		void Update(){
			
		if (GameObject.Find ("LevelControl").GetComponent<LevelControl> ().chovendoFase == true) {
			if (chovendo == false) {
				Enable ();
			}
		}

		if (GameObject.Find ("LevelControl").GetComponent<LevelControl> ().chovendoFase == false) {
			if (chovendo == true) {
				Disable ();
			}
		}
		
	}
		void Spawn ()
		{
			// If the player has no health left...
			if(this.chovendo == false)
			{
				// ... exit the function.
				return;
			}
			
			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			
			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (poca, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}

	public void Enable(){
		Debug.Log ("chuva");
		chovendo = true;
		InvokeRepeating ("Spawn", 1f, spawnTime);
	}

	public void Disable(){
		chovendo = false;
	}


	}
