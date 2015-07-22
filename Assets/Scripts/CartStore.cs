﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CartStore : MonoBehaviour {
	
	List<Cart> carts;
	
	public Transform marker;
	public float speed = 1f;
	public int capacity, contados_pontos;
	public Material buttonOff;
	public Material buttonOn;
	public GameObject[] buttons;
	public GerenciarExtras gerenciarExtras;
	
	
	// Use this for initialization
	void Start () {
		carts = new List<Cart>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		foreach(var cart in carts){
			
			var p = cart.GetComponent<Rigidbody>().position;
			p.x = marker.position.x;
			cart.GetComponent<Rigidbody>().MovePosition(p);
			cart.GetComponent<Rigidbody>().MoveRotation(marker.rotation);
			cart.GetComponent<Rigidbody>().velocity = marker.forward * speed;
			cart.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
	}
	
	public void OnTriggerEnterStair(Collider col){
		if(carts.Count < capacity && col.gameObject.CompareTag("Cart")){

			Cart cart = col.GetComponent<Cart>();
			cart.colectable = false;

			if(!carts.Contains(cart)){
				cart.DetachFrom();
				carts.Add(cart);
				cart.canBeAttached = false;
				
				if(carts.Count == capacity){
					foreach(var button in buttons){
						button.GetComponent<Renderer>().material = buttonOn;
					}
				}
			}
		}
	}
	public void OnTriggerEnterButton(Collider col){
		if(carts.Count == capacity && col.gameObject.CompareTag("Player")){
			
			foreach(var cart in carts.ToArray()){
				Destroy(cart.gameObject);
			}
			carts.Clear();
			foreach(var button in buttons){
				button.GetComponent<Renderer>().material = buttonOff;
			}
			Player.Instance.points += capacity;
			Market.Instance.currentFreeCarts -= capacity;
			
			//gerenciarExtras.gerarPremios();
			//contador
			InstaciarMoedas.Instance.Spawn(1);
			//instaciadorMoedas.Spawn();
			//GerenciarExtras.Instance.AddCoin(0);
			
		}
	}
}
