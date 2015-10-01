using UnityEngine;
using System.Collections;
using System.Linq;

public class Vehicle : MonoBehaviour {

	public enum State { None, SearchingParking, Parked, ExitParking }

	[HideInInspector]
	public State state = State.None;

	public Vaga vaga;

	public AudioClip impact;
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();

		Game.Instance.vehicleManager.vehicles.Add(this);
		StartCoroutine(SetVaga(Game.Instance.vagasManager.FindEmptyVaga()));
	}

	public IEnumerator SetVaga(Vaga vaga){
		this.vaga = vaga;
		vaga.owner = this;
		this.GetComponent<NavMeshAgent>().destination = vaga.transform.position;
		yield return new WaitForEndOfFrame();
		state = State.SearchingParking;
	}

	void Update(){

		var agent = this.GetComponent<NavMeshAgent>();

		switch(state){
		case State.None:
			break;
		case State.SearchingParking:
			if(agent.hasPath && agent.remainingDistance < 0.5f){
				state = State.Parked;
				CreatePedestrian();
				//Invoke("ChangeToExit", 1f);
				//Invoke(ChangeToExit, 1f);
				//StartCoroutine(ChangeToExit(Random.Range(3f,10f)));
			}
			break;
		case State.Parked:
			break;
		case State.ExitParking:

			break;
		}
	}

	void OnDestroy(){
		if(Application.isPlaying){
			if(Game.Instance && Game.Instance.vehicleManager){
				Game.Instance.vehicleManager.vehicles.Remove(this);
			}
		}
	}

	void CreatePedestrian (){

		var pos = this.transform.position - this.transform.forward;
		var rot = Quaternion.Euler(0,180,0) * this.transform.rotation;
		Pedestrian pedestrian = (Pedestrian)Instantiate(Game.Instance.pedestrianManager.pedestrianPrefab, pos, rot);
		pedestrian.transform.SetParent(Game.Instance.pedestrianManager.transform);
		pedestrian.vehicle = this;
	}

	public void ChangeToExit(){
		StartCoroutine(ChangeToExitCorountine());
	}
	IEnumerator ChangeToExitCorountine(){
		this.GetComponent<NavMeshAgent>().destination = Game.Instance.exit.position;
		yield return new WaitForEndOfFrame();
		state = State.ExitParking;
		this.vaga.owner = null;
		this.vaga = null;
	}

	void OnCollisionEnter() {
		audio.PlayOneShot(impact, 0.11F);
	}

	void OnTriggerEnter(Collider col){
		if(col.CompareTag("Exit")){
			Destroy(this.gameObject);
		}
	}

}
