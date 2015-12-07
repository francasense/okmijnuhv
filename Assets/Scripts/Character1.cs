using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public Animator animator;
	public bool walk;
	public bool cart;
	public bool changeColors = true;

	public Material[] skinColors;
	public Material[] clothColors;
	public Material[] eyeColors;
	public Material[] feetColors;
	public Material[] hairColors;

	public Transform[] skins;
	public Transform[] hairs;
	public Transform[] eyes;
	public Transform[] shirts;
	public Transform[] pants;
	public Transform[] feets;


	void Start () {
		animator = GetComponent<Animator>();
		if(changeColors){
			SetColors();
		}
	}

	void LateUpdate () {
		animator.SetBool("walking", walk);
		animator.SetBool("cart", cart);
	}


	public void SetColors(){
		Material skinColor = skinColors[Random.Range(0,skinColors.Length)];
		Material hairColor = hairColors[Random.Range(0,hairColors.Length)];
		Material eyeColor = eyeColors[Random.Range(0,eyeColors.Length)];
		Material shirtsColor = clothColors[Random.Range(0,clothColors.Length)];
		Material pantsColor = clothColors[Random.Range(0,clothColors.Length)];
		Material feetColor = feetColors[Random.Range(0,feetColors.Length)];

		foreach(var t in skins) t.GetComponent<MeshRenderer>().material = skinColor;
		foreach(var t in hairs) t.GetComponent<MeshRenderer>().material = hairColor;
		foreach(var t in eyes) t.GetComponent<MeshRenderer>().material = eyeColor;
		foreach(var t in shirts) t.GetComponent<MeshRenderer>().material = shirtsColor;
		foreach(var t in pants) t.GetComponent<MeshRenderer>().material = pantsColor;
		foreach(var t in feets) t.GetComponent<MeshRenderer>().material = feetColor;

	}

}
