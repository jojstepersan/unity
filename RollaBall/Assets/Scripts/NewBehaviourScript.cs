
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public int resistencia;
    public Transform ob;
    public ParticleSystem systemaParticulas;
	//public AudioSource sonido;
	public float yPosicion;
    private bool rotar = false;
    private Rigidbody rb;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotar){
            transform.Rotate(new Vector3(45, 45, 45) * Time.deltaTime * 3);
        }
    }

	public void RegistrarImpacto(Vector3 puntoImpacto){
        resistencia--;
		//systemaParticulas = systemaParticulas.GetComponent<ParticleSystem> ();
		systemaParticulas.transform.position = puntoImpacto;
		systemaParticulas.Play ();
		//sonido.Play ();
       

		if (gameObject.CompareTag ("PaBajo")) {
            rotar = !rotar;

			//transform.position = new Vector3 (transform.position.x, transform.position.y -1, transform.position.z);
		
			Debug.Log ("elav");
		
		}
		if (gameObject.CompareTag ("Recolectable")) {
            gameObject.AddComponent<Rigidbody>();
            //	transform.position = new Vector3 (transform.position.x, transform.position.y +1, transform.position.z);
        }


      

    }

    void OnParticleCollision(GameObject other)
    {
        if (gameObject.CompareTag("Recolectable"))
        {
            gameObject.AddComponent<Rigidbody>();

            Debug.Log("colision cubo");
            //Destroy(transform.gameObject);
        }

    }

}

