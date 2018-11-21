using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class controlEnemigo : MonoBehaviour {

	Transform posicionJugador;
	NavMeshAgent agente;
	void Start () {
		posicionJugador = GameObject.FindGameObjectWithTag ("Jugador").transform;
		agente = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agente.SetDestination (posicionJugador.position);
	}
}
