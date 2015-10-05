using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

	public Material[] colors;

	public Renderer[] renderers;

	// Use this for initialization
	void Start () {
		var mat = colors[Random.Range(0,colors.Length)];
		foreach(var rend in renderers){
			rend.material = mat;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
