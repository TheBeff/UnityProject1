using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;
	private Animator shake;

	//these variables will set the bounds for the enemy to move within
	private float targetYMin;
	public float targetYMax;
	public float targetXMin;
	public float targetXMax;

	//these variables help us manage position for enemy movement targets
	private Vector2 targetPosition;
	private Vector2 newVelocity;
	private float distanceToTarget;

	//how close the enemy should get to its target before it picks another one
	public float targetBounceDistance;

	public float enemySpeed;
	private int level;

	//these are variables for Bob's attack
	public float timeToAttack;
	private float timer;
	private bool attacking;
	private GameObject glove;
	Rigidbody2D gloveRb;
	GloveHealth gloveHealth;

	//sound variables

	public AudioClip bobOw;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		shake = Camera.main.GetComponent<Animator> ();

		level = GameObject.Find ("EnemySpawner").GetComponent<SpawnerScript> ().level;

		//the minimum Y value for the enemy should be determined by the player's "safe zone" size
		targetYMin = GameObject.Find ("GameManager").GetComponent<GameManager> ().safeZoneMax;

		selectRandomTarget ();

		timer = timeToAttack;
		attacking = false;
		glove = GameObject.Find ("glove");
		gloveRb = glove.GetComponent<Rigidbody2D> ();
		gloveHealth = glove.GetComponent<GloveHealth> ();

	}
	
	// Update is called once per frame
	void Update () {

		//countdown to attack
		timer -= Time.deltaTime;

		//how close the enemy is to its target
		distanceToTarget = (targetPosition - rb.position).magnitude;

		//if it's time to attack, do so
		if (timer <= 0) {
			attacking = true;
		} 

		if (attacking) {
			attack ();
		} else {
			//else, if Bob is further than the limit we've set, move towards the target
			//otherwise, select a new one
			if (distanceToTarget > targetBounceDistance) {
				newVelocity = (targetPosition - rb.position).normalized * (enemySpeed + level);
				rb.velocity = newVelocity;
			} else {
				selectRandomTarget ();
			}	
		}


	}
		
	//this function selects a random positional target based on the coordinate bounds we set
	void selectRandomTarget () {
		targetPosition = new Vector2 (Random.Range (targetXMin, targetXMax), Random.Range(targetYMin, targetYMax));
	}

	void attack(){
		Debug.DrawRay (transform.position, glove.transform.position);
		Debug.Log ("attacked!");
		newVelocity = (gloveRb.position - rb.position).normalized * (enemySpeed * (level + 1));
		rb.velocity = newVelocity;
	}

	void damage(){
		Debug.Log ("doing damage");
		gloveHealth.health--;
		Debug.Log ("health: " + gloveHealth.health);
		attacking = false;
		timer = timeToAttack;
	}

	//make the screen shake if bob is punched

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Player") && !attacking){
			anim.SetBool("Punched", true);
			GetComponent<AudioSource> ().PlayOneShot (bobOw);
			//shake.SetBool("Punched", true);
			shake.Play("ScreenShake");
		}

		if (coll.gameObject.CompareTag ("Player") && attacking) {
			damage ();
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Player")){
			anim.SetBool ("Punched", false);
			//shake.Play("ScreenShake_Idle");
		}
	}
}
