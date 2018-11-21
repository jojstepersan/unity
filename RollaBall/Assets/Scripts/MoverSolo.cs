using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSolo : MonoBehaviour {
	public GameObject CuboMovible;

	// Use this for initialization
	void Start () {
		StartCoroutine ("Movimiento");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Movimiento(){

		for (;;) {
			if(Vector3.Distance (transform.position, CuboMovible.transform.position)<6){

				CuboMovible.transform.position = Vector3.Lerp (CuboMovible.transform.position,
					transform.position,
					8f * Time.deltaTime);

			}

			yield return new WaitForSecondsRealtime (0.1f);
		}
		//StartCoroutine (Movimiento());
	}
}
