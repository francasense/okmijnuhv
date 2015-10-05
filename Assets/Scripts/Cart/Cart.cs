using UnityEngine;
using System.Collections;

public class Cart : MonoBehaviour {

	private static Cart instance;
	public static Cart Instance{get{return instance == null ? instance = FindObjectOfType<Cart>() : instance;}}


	public bool colectable = true;
	public bool empty = true;

	[HideInInspector]
	public FixedJoint joint;

	[HideInInspector]
	public bool canBeAttached = true;

	ICartHandler cartHandler = null;

	public Transform stuff;

	bool firstOfLine = false;

	void Awake(){
		stuff.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		Market.Instance.currentFreeCarts++;

	}
	
	// Update is called once per frame
	void Update () {
	if (stuff.gameObject.activeSelf == true) {
			this.empty = false;
		} else if (stuff.gameObject.activeSelf == false) {
			this.empty = true;
		}
	}

	public void DetachFrom(){
		if(this.joint && this.joint.connectedBody && cartHandler != null){
			Destroy(this.joint);
			cartHandler.currentCart = null;
			cartHandler = null;
			this.joint = null;
			canBeAttached = true;
		}
	}
	public void AttachTo(ICartHandler cartHandler){
		var carTransform = cartHandler.GetComponent<Transform>();
		this.transform.position = carTransform.position + carTransform.forward * 1.1f;
		this.transform.rotation = carTransform.rotation;
		this.joint = this.gameObject.AddComponent<FixedJoint>();
		this.joint.connectedBody = cartHandler.GetComponent<Rigidbody>();
		cartHandler.currentCart = this;
		canBeAttached = false;
		this.cartHandler = cartHandler;
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.CompareTag("Player")){
			Player p = Player.Instance;
			if(p.currentCart == null && this.joint == null && canBeAttached){
				AttachTo(Player.Instance);
				this.colectable = false;
			}
		}

		if(col.gameObject.CompareTag("Helper")){

			Helper h = Helper.Instance;
			if(h.currentCart == null && this.joint == null && canBeAttached){
				AttachTo(Helper.Instance);
			}
		}
	}



	public void Coletavel(){
		this.colectable = false;
	}

	void OnTriggerEnter(Collider col){

	}
}
