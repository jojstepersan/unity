using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SalirAplicacion(){
		Debug.Log ("Saliendo de la app");
		Application.Quit();
	}
}
