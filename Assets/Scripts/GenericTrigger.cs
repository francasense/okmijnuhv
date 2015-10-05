using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GenericTrigger : MonoBehaviour {

	public enum GenericTriggerType{
		Awake = 0,
		Start = 1,
		FixedUpdate = 2,
		Update = 3,
		LateUpdate = 4,
		OnApplicationGetFocus = 5,
		OnApplicationLostFocus = 6,
		OnApplicationPause = 7,
		OnApplicationResume = 8,
		OnApplicationQuit = 9,
		OnBecameInvisible = 10,
		OnBecameVisible = 11,
		OnDestroy = 12,
		OnEnable = 13,
		OnDisable = 14,
		OnLevelWasLoaded = 15,
		OnCollisionEnter = 16,
		OnCollisionStay = 17,
		OnCollisionExit = 18,
		OnTriggerEnter = 19,
		OnTriggerStay = 20,
		OnTriggerExit = 21,
	}

	[System.Serializable]
	public class UnityEventCollision : UnityEvent<Collision>{}

	[System.Serializable]
	public class UnityEventCollider : UnityEvent<Collider>{}

	[Serializable]
	public class Entry{
		public GenericTriggerType eventID = GenericTriggerType.Awake;
		public UnityEvent callback = new UnityEvent();
		public UnityEventCollision callbackCollision = new UnityEventCollision();
		public UnityEventCollider callbackCollider = new UnityEventCollider();
	}

	public List<Entry> delegates;

	public static bool IsCollision(GenericTriggerType id){
		return id == GenericTriggerType.OnCollisionEnter ||
			id == GenericTriggerType.OnCollisionStay ||
				id == GenericTriggerType.OnCollisionExit;
	}
	public static bool IsCollider(GenericTriggerType id){
		return id == GenericTriggerType.OnTriggerEnter ||
			id == GenericTriggerType.OnTriggerStay ||
				id == GenericTriggerType.OnTriggerExit;
	}

	private void Execute(GenericTriggerType id, object param = null){
		if (delegates != null){
			for (int i = 0, imax = delegates.Count; i < imax; ++i){
				var ent = delegates[i];
				if (ent.eventID == id && ent.callback != null){
					if(IsCollision(id)){
						ent.callbackCollision.Invoke(param as Collision);
					}else if(IsCollider(id)){
						ent.callbackCollider.Invoke(param as Collider);
					}else{
						ent.callback.Invoke();
					}
				}
			}
		}
	}

	void Awake(){Execute(GenericTriggerType.Awake);}
	void Start(){Execute(GenericTriggerType.Start);}
	void FixedUpdate(){Execute(GenericTriggerType.FixedUpdate);}
	void Update(){Execute(GenericTriggerType.Update);}
	void LateUpdate(){Execute(GenericTriggerType.LateUpdate);}
	void OnApplicationFocus(bool focusStatus){Execute(focusStatus ? GenericTriggerType.OnApplicationGetFocus : GenericTriggerType.OnApplicationLostFocus);}
	void OnApplicationPause(bool pauseStatus){Execute(pauseStatus ? GenericTriggerType.OnApplicationPause : GenericTriggerType.OnApplicationResume);}
	void OnApplicationQuit(){Execute(GenericTriggerType.OnApplicationQuit);}
	void OnBecameInvisible(){Execute(GenericTriggerType.OnBecameInvisible);}
	void OnBecameVisible(){Execute(GenericTriggerType.OnBecameVisible);}
	void OnDestroy(){Execute(GenericTriggerType.OnDestroy);}
	void OnEnable(){Execute(GenericTriggerType.OnEnable);}
	void OnDisable(){Execute(GenericTriggerType.OnDisable);}
	void OnLevelWasLoaded(){Execute(GenericTriggerType.OnLevelWasLoaded);}
	void OnCollisionEnter(Collision col){Execute(GenericTriggerType.OnCollisionEnter,col);}
	void OnCollisionStay(Collision col){Execute(GenericTriggerType.OnCollisionStay,col);}
	void OnCollisionExit(Collision col){Execute(GenericTriggerType.OnCollisionExit,col);}
	void OnTriggerEnter(Collider col){Execute(GenericTriggerType.OnTriggerEnter,col);}
	void OnTriggerStay(Collider col){Execute(GenericTriggerType.OnTriggerStay,col);}
	void OnTriggerExit(Collider col){Execute(GenericTriggerType.OnTriggerExit,col);}

}
