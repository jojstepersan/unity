using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotar : MonoBehaviour {
	public Transform ob;
	private bool pressed;
	Material material;
	private Vector3 posicion;
	private float x;
	private float y;
	private float z;
	public Slider slX;
	public Slider slY;
	public Slider slZ;
	public Slider sl;



	// Use this for initialization
	void Start () {
		pressed=false;
		material = ob.GetComponent<Renderer> ().material;
		material.color = Color.black;
		posicion = ob.transform.position;
		x = ob.transform.position.x;
		y = ob.transform.position.y;
		z = ob.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(pressed){
			ob.Rotate (new Vector3(45,45,45)*Time.deltaTime*3);
		}		
	}

	public void press (){
		Debug.Log ("presionado");
		if(pressed == false){
			pressed=true;
		}else{
			pressed=false;
		}
	}

	public void EscalarCubo(float value){
		ob.localScale = new Vector3 (value,value,value);
	}

	public void moverX(float value){
		float xPosicion = posicion.x+value;
		ob.transform.position = new Vector3 (xPosicion,y,z);
		x = xPosicion;
	}

	public void moverY(float value){
		float yPosicion = posicion.y+value;
		ob.transform.position = new Vector3 (x,yPosicion,z);
		y = yPosicion;
	}

	public void moverZ(float value){
		float zPosicion = posicion.z+value;
		ob.transform.position = new Vector3 (x,y,zPosicion);
		z = zPosicion;
	}

	public void reiniciar(){
		ob.transform.position = new Vector3 (491.81f,291.557f,13);
		ob.transform.rotation = Quaternion.identity;
		ob.transform.localScale =  new Vector3 (2,2,2);
		material.color = Color.black;
		slX.value = 0;
		slY.value = 0;
		slZ.value = 0;
		sl.value = 0;
		pressed=false;
	}

	public void CambiarColor(int opcion){
		switch(opcion){
		case 0:
			Debug.Log ("Opcion 1");
			material.color = Color.black;
			break;
		case 1:
			Debug.Log ("Opcion 1");
			material.color = Color.red;
			break;
		case 2:
			Debug.Log ("Opcion 1");
			material.color = Color.yellow;
			break;
		}
	}

}
