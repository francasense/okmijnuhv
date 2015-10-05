using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VagasManager : MonoBehaviour {

	[HideInInspector]
	public Vaga[] vagas;


	void Awake () {
		vagas = this.GetComponentsInChildren<Vaga>();
	}

	public Vaga FindEmptyVaga (){
		Vaga[] empties = (from v in vagas where v.owner == null select v).ToArray();
		return empties[Random.Range(0,empties.Length)];
	}

}
