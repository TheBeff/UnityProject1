using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D rb;

	//these variables will set the bounds for the enemy to move within
	float targetYMin;
	public float targetYMax;
	public float targetXMin;
	public float targetXMax;

	Vector2 currentPosition;
	Vector2 targetPosition;
	Vector2 newVelocity;
	float distanceToTarget;

	public float targetBounceDistance;

	public float enemySpeed;

	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();

		currentPosition = rb.position;
		targetYMin = GameObject.Find ("GameManager").GetComponent<GameManager> ().safeZoneMax;

		selectRandomTarget ();

	}
	
	// Update is called once per frame
	void Update () {
		
		distanceToTarget = (targetPosition - rb.position).magnitude;

		if (distanceToTarget > targetBounceDistance) {
			newVelocity = (targetPosition - rb.position).normalized * enemySpeed;
			rb.velocity = newVelocity;
		} else {
			selectRandomTarget ();
		}

	}

	void selectRandomTarget () {
		targetPosition = new Vector2 (Random.Range (targetXMin, targetXMax), Random.Range(targetYMin, targetYMax));
	}
}
