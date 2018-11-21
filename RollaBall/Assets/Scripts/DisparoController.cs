using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoController : MonoBehaviour {

	public GameObject player;
	public float tiempoEntreDisparo = 1f;
	public float rango = 100f;
    public Transform particulas;
    private ParticleSystem systemaParticulas;

    float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplaytime = 1.2f;

	// Use this for initialization
	void Start () {
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= tiempoEntreDisparo * effectsDisplaytime) {
			DisableEffects ();
		}
		
	}

	void Awake(){
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> ();
		gunLight = GetComponent<Light> ();

	}

	void DisableEffects(){
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot(){
		Vector3 ubicacion = new Vector3 (player.transform.position.x,
			                   player.transform.position.y + 1.1f,
			                   player.transform.position.z);
		timer = 0f;
		gunLine.enabled = true;
		gunLight.enabled = true;
		shootRay.origin = ubicacion;
		shootRay.direction = transform.forward;
		gunLine.SetPosition (0, ubicacion);                                  
		if (Physics.Raycast (shootRay, out shootHit, rango, shootableMask)) {
			
			//Destroy (shootHit.collider.gameObject);


			NewBehaviourScript resistencia = shootHit.collider.gameObject.GetComponent <NewBehaviourScript> ();
			if (resistencia != null)
				resistencia.RegistrarImpacto (shootHit.point);
			gunLine.SetPosition (1, shootHit.point);



            player.transform.position = new Vector3(player.transform.position.x *-1.0f, player.transform.position.y, player.transform.position.z * - 1.0f);
            particulas.position = player.transform.position;
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();
            StartCoroutine(DetenerParticulas(systemaParticulas));
        } else {
			Debug.Log ("No se impacto con ningun elemento");
			gunLine.SetPosition(1,shootRay.origin + shootRay.direction*rango);
		}
	}



    public IEnumerator DetenerParticulas(ParticleSystem part)
    {
        yield return new WaitForSecondsRealtime(0.8f);

        part.Stop();
    }

}
