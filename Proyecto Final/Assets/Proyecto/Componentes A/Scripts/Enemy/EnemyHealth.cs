using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 100;            // The amount of health the enemy starts the game with.
        public int currentHealth;                   // The current health the enemy has.
        public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
        public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
        public AudioClip deathClip;                 // The sound to play when the enemy dies.
        public int score2 = 5;

        Animator anim;                              // Reference to the animator.
        AudioSource enemyAudio;                     // Reference to the audio source.
        ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
        CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
        bool isDead;                                // Whether the enemy is dead.
        bool isSinking;                             // Whether the enemy has started sinking through the floor.


        

        public int resistencia;
        void Start()
        {
            
        }
        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            enemyAudio = GetComponent <AudioSource> ();
            hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // Setting the current health when the enemy first spawns.
            currentHealth = startingHealth;
        }


        void Update ()
        {
            // If the enemy should be sinking...
            if(isSinking)
            {
                // ... move the enemy down by the sinkSpeed per second.
                transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }


        public void TakeDamage (int amount, Vector3 hitPoint)
        {
            // If the enemy is dead...
            
            if(isDead)
                // ... no need to take damage so exit the function.
                return;
            enemyAudio.Play ();
            currentHealth -= amount;
            hitParticles.transform.position = hitPoint;

            // And play the particles.
            hitParticles.Play();

            // If the current health is less than or equal to zero...
            if(currentHealth <= 0)
            {
                // ... the enemy is dead.
                Death ();
            }
        }


        void Death ()
        {
            // The enemy is dead.
            isDead = true;

           
            capsuleCollider.isTrigger = true;
            anim.SetTrigger("Dead");
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();
        }
        public void RegistrarImpacto(Vector3 puntoImpacto)
        {            
            resistencia--;
            if (resistencia == 0)
            {
                Destroy(gameObject);
                ScoreManager.score += score2;
            }
        }
        public IEnumerator DetenerParticulas(ParticleSystem part)
        {
            yield return new WaitForSecondsRealtime(0.8f);

            part.Stop();
        }

        public void StartSinking ()
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            GetComponent <Rigidbody> ().isKinematic = true;
            isSinking = true;
            ScoreManager.score += scoreValue;
            
            Destroy (gameObject, 2f);
        }
    }

   
}