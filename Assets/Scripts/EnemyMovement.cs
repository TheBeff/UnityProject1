﻿using System.Collections;
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

	public AudioClip bobOw;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		shake = Camera.main.GetComponent<Animator> ();

		//the minimum Y value for the enemy should be determined by the player's "safe zone" size
		targetYMin = GameObject.Find ("GameManager").GetComponent<GameManager> ().safeZoneMax;

		selectRandomTarget ();

	}
	
	// Update is called once per frame
	void Update () {

		//how close the enemy is to its target
		distanceToTarget = (targetPosition - rb.position).magnitude;

		//if its further than the limit we've set, move towards the target
		//otherwise, select a new one
		if (distanceToTarget > targetBounceDistance) {
			newVelocity = (targetPosition - rb.position).normalized * enemySpeed;
			rb.velocity = newVelocity;
		} else {
			selectRandomTarget ();
		}

	}
		
	//this function selects a random positional target based on the coordinate bounds we set
	void selectRandomTarget () {
		targetPosition = new Vector2 (Random.Range (targetXMin, targetXMax), Random.Range(targetYMin, targetYMax));
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Player")){
			anim.SetBool("Punched", true);
			GetComponent<AudioSource> ().PlayOneShot (bobOw);
			//shake.SetBool("Punched", true);
			shake.Play("ScreenShake");
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Player")){
			anim.SetBool ("Punched", false);
			//shake.Play("ScreenShake_Idle");
		}
	}
}
