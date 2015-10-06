using UnityEngine;
using System.Collections;
	
	public class targetMove : MonoBehaviour
	{
		public float smoothing = 1f;
		public Transform target1;
		public Transform target2;
		public Transform target3;
		public Transform target4;
		public Transform target5;
		public Transform target6;
		public Transform target7;
		public Transform target8;

	public Transform targetPlayer;
	public Transform targetDireita;

	public Transform targetEsquerda;


	public bool testDog;
	public DodWalk dodWalk;
	public bool testPau;
	public bool escolherLado;
	public lancarPau lancarPaus; 
		
		
		void Start ()
		{
		testPau = false;

		StartCoroutine(randomTarget());
		}
		
		
		IEnumerator randomTarget(){
		yield return null;

		int num = Random.Range(1, 8);

		switch (num)
		{
		case 1:
			StartCoroutine(MyCoroutine(target1));
			break;
		case 2:
			StartCoroutine(MyCoroutine(target2));
			break;
		case 3:
			StartCoroutine(MyCoroutine(target3));
			break;
		case 4:
			StartCoroutine(MyCoroutine(target4));
			break;
		case 5:
			StartCoroutine(MyCoroutine(target5));
			break;
		case 6:
			StartCoroutine(MyCoroutine(target6));
			break;
		case 7:
			StartCoroutine(MyCoroutine(target7));
			break;
		case 8:
			StartCoroutine(MyCoroutine(target8));
			break;
		}

		}
		IEnumerator MyCoroutine (Transform target)
		{
			while(Vector3.Distance(transform.position, target.position) > 0.05f)
			{
				transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
				yield return null;
			}			
			yield return new WaitForSeconds(1f);

		if(testDog){
			StartCoroutine(randomTarget());
		}else{
			StartCoroutine(randomTarget2());

		}
	}

	IEnumerator MyCoroutine2 (Transform target)
	{
		while(Vector3.Distance(transform.position, target.position) > 0.05f)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
			yield return null;
		}		
		StartCoroutine(randomTarget2());

	}


	IEnumerator randomTarget2(){
		yield return null;
		StartCoroutine(MyCoroutine2(targetPlayer));


	}
	void Update () {//walk
		testDog = dodWalk.testTarget;
		escolherLado = lancarPaus.testPaus;
		testPau = lancarPaus.Resultado;

		if(testPau){
			StartCoroutine(randomTarget3());
		}
	}

	IEnumerator randomTarget3(){
		yield return null;

		if(escolherLado){
			StartCoroutine(MyCoroutine3(targetDireita));
		}else{
			StartCoroutine(MyCoroutine3(targetEsquerda));
		}

	}

	IEnumerator MyCoroutine3 (Transform target)
	{
		while(Vector3.Distance(transform.position, target.position) > 0.05f)
		{
			transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
			yield return null;
		}		

	}

}