using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, ICartHandler {
	
	private static Player instance;
	public static Player Instance{get{return instance == null ? instance = FindObjectOfType<Player>() : instance;}}
	
	public float speed;
	public float turnSpeed = 100;
	public float stopDistance = 0.5f;
	
	[HideInInspector]
	public Vector3 destination;
	
	public Cart currentCart {get; set;}
	
	[HideInInspector]
	public int points;
	
	public UnityEngine.UI.Text pointsText;
	
	public Character character;
	
	void Start () {
		//speed = 10;
		Time.timeScale = 1f;
		points = 0;
		destination = this.transform.position;
		
		character.walk = character.cart = false;
	}
	
	void Update(){
		
		//destination preenchido pelo mouse ou touch
		
		//if(currentCart != null && Input.GetKeyDown(KeyCode.Z))currentCart.DetachFrom();
		
		pointsText.text = points.ToString();
		
		character.cart = currentCart != null;
	}
	
	
	void FixedUpdate () {
		
		var dir = destination-this.transform.position;
		var dirn = dir.normalized;
		
		var rb = GetComponent<Rigidbody>();
		
		if(dir.magnitude > stopDistance){
			character.walk = true;
			
			//moving
			rb.velocity = dirn * speed;
			
			//turn
			float angle = Vector3.Angle(this.transform.forward,dirn);
			if(angle > 10f){
				var factor = Mathf.Clamp01(angle / 10f);
				var distRight = Vector3.Distance(this.transform.position + this.transform.right, destination);
				var distLeft = Vector3.Distance(this.transform.position - this.transform.right, destination);
				var turnDir = distLeft < distRight ? -1 : 1;
				var av = rb.angularVelocity;
				av.y = factor * turnDir * turnSpeed;
				rb.angularVelocity = av;
			}else{
				rb.angularVelocity = Vector3.zero;
			}
		}else{
			character.walk = false;
			rb.velocity = rb.angularVelocity = Vector3.zero;
		}
	}
	
	public void ReloadLevel(){
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
	public void SuperSpeed(int teste)
	{
		if (teste==1){
			StartCoroutine(superVelocity());
		}
	}
	public IEnumerator superVelocity(){

		GerenciarExtras.Instance.super.SetActive(true);
		Player.Instance.speed=25;
		yield return new WaitForSeconds (18.0f);
		Player.Instance.speed=8;
		GerenciarExtras.Instance.super.SetActive(false);
		
	}
}
