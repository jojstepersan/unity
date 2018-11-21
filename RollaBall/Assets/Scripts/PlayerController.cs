using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private int contador;
	public float speed;
	public Transform particulas;
	private ParticleSystem systemaParticulas;
	private AudioSource audioRecoleccion;
	public Text textoContador;
	public Text textoGanador;
	public GameObject CuboMovible;
	public GameObject poder;
	private Vector3 posicion;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		contador = 0;
		systemaParticulas = particulas.GetComponent<ParticleSystem> ();
		systemaParticulas.Stop();
		audioRecoleccion = GetComponent<AudioSource> ();
		textoContador.text = "Contador:" + contador.ToString ();

		StartCoroutine ("Movimiento");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movimiento = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce (movimiento * speed);
	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag ("Recolectable")) {
			

			posicion = other.gameObject.transform.position;

			particulas.position = posicion;

			systemaParticulas = particulas.GetComponent<ParticleSystem> ();
			systemaParticulas.Play ();
			StartCoroutine (DetenerParticulas(systemaParticulas));

			Destroy(other.gameObject);
			audioRecoleccion.Play ();
			//other.gameObject.SetActive (false);
			contador++;

			if (contador > 16) {
				textoContador.text = "Ganador";
				textoGanador.text = "Ganador";
			} else {
				Debug.Log (contador);
				textoContador.text = "Contador:" + contador.ToString ();
			}
				
		} 
	}

	public IEnumerator DetenerParticulas(ParticleSystem part){
		yield return new WaitForSecondsRealtime (0.9f);

		part.Stop ();
	}

	public IEnumerator Movimiento(){

		for (;;) {
			if(Vector3.Distance (transform.position, CuboMovible.transform.position)<6){

				CuboMovible.transform.position = Vector3.Lerp (CuboMovible.transform.position,
					new Vector3 (Random.Range (-10.0f, 10.0f), 0.97f, Random.Range (-10.0f, 10.0f)),
					8f * Time.deltaTime);

			}

			yield return new WaitForSecondsRealtime (0.1f);
		}
		//StartCoroutine (Movimiento());
	}

}
