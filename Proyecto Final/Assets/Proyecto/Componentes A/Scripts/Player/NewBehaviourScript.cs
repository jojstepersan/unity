using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int resistencia;
    public ParticleSystem systemaParticulas;
    public AudioSource sonido;
  

   
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    public void RegistrarImpacto(Vector3 puntoImpacto)
    {
        resistencia--;
        systemaParticulas = systemaParticulas.GetComponent<ParticleSystem> ();
        systemaParticulas.transform.position = puntoImpacto;
        systemaParticulas.Play();
        sonido.Play ();


    }

 

}

