using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	//ponto pra onde o personagem vai
	public Waypoints way;

	//velocidade
	public float speed = 5;

	//ponto destino sempre ao lado do waypoint
	Vector3 destino;
	//quando vai desviar do waypoint
	//se for positiva fica de um lado, se for negativo fica do outro
	//assim cada personagem pode buscar uma posiçao relativa diferente
	public float desvio = 1f;

	void Start(){
		destino = way.transform.position;
	}

	void Update () {

		//direçao atual
		Vector3 dir = 
			destino-this.transform.position;
		//anula o y
		dir.y = 0;

		//se a distancia (magnitude) for pequena, chegou no destino
		if(dir.magnitude < 0.5f){

			//escolhe um destino aleatorio
			//isso pode virar uma funçao que escolhe algum dos waypoints a frente dele
			//se nao tiver nenhum waypoint na frente dele ai sim ele pode escolher algum atraz
			way = way.nexts[Random.Range(0,way.nexts.Count)];

			//nova direçao pro novo alvo
			Vector3 newDir = 
				(way.transform.position-
					this.transform.position).normalized;

			//o destino fica ao lado do waypoint
			//so pegar a direçao e girar 90º em y
			//pra girar um vetor vc multiplica por um quaternion
			//o desvio diz quanto vai desviar pro lado (positivo ou negativo)
			destino = way.transform.position +
				Quaternion.Euler(0,90,0) * newDir * desvio;

			//guarda a nova direçao ignorando o y
			dir = newDir;
			dir.y = 0;

		}

		//rotaciona o personagem para ficar de frente pro destino
		this.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

		//usa a velocidade atual e muda apenas x e z
		//o y e controlado pela gravidade
		Vector3 vel = this.GetComponent<Rigidbody>().velocity;
		dir = dir.normalized;
		vel.x = dir.x * speed;
		vel.z = dir.z * speed;
		this.GetComponent<Rigidbody>().velocity = vel;
	}

	//desenhar linha em direçao ao destino
	//apenas pra ver pra onde ele vai em ediçao
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawLine(this.transform.position, destino);
	}

}
