using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Rigidbody2D rb;

	float targetYMin;
	public float targetYMax;
	public float targetXMin;
	public float targetXMax;

	Vector3 currentPosition;
	Vector3 targetPosition;

	public float enemySpeed;

	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();

		currentPosition = transform.position;
		targetYMin = GameObject.Find ("GameManager").GetComponent<GameManager> ().safeZoneMax;

		targetPosition = new Vector3 (Random.Range (targetXMin, targetXMax), Random.Range(targetYMin, targetYMax), 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
