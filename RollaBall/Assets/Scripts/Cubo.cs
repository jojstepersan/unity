using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cubo : MonoBehaviour {

	public Transform cubito;
	// Use this for initialization
	void Start () {
		
		StartCoroutine (DesaparecerCubo());
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}


	public IEnumerator DesaparecerCubo(){
		
		yield return new WaitForSecondsRealtime (1);
		if(cubito!=null){
			cubito.gameObject.SetActive (false);
		}
		
		yield return new WaitForSecondsRealtime (1);
		if(cubito!=null){
			cubito.gameObject.SetActive (true);
			StartCoroutine (DesaparecerCubo());
		}
	}

}
