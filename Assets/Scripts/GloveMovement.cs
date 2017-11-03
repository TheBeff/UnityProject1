using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMovement : MonoBehaviour {

	Rigidbody2D rb;

	private bool isMoving = false;

	private Vector2 startPosition;
	private Vector2 currentPosition;
	private Vector2 newVelocity;

	public float gloveSpeed;
	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();
		startPosition = new Vector2 (0, -3.6f);
		currentPosition = rb.position;
	}
	
	// Update is called once per frame
	void Update () {

//		newVelocity = (startPosition - currentPosition).normalized * gloveSpeed;
//
//		if (!isMoving) {
//			rb.velocity = newVelocity;
//		}
	}

	void moveGlove(){
		if(Input.GetKey(KeyCode.S)){
			isMoving = true;
			rb.velocity = new Vector2(0, -1 * gloveSpeed);
		}

		if(Input.GetKey(KeyCode.W)){
			isMoving = true;
			print ("ur pushing W");
			rb.velocity = new Vector2(0, gloveSpeed);
		}

		if(Input.GetKey(KeyCode.A)){
			isMoving = true;
			rb.velocity = new Vector2(-1 * gloveSpeed, 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			isMoving = true;
			rb.velocity = new Vector2 (gloveSpeed, 0);
		} else {
			isMoving = false;
		}
	}
}
