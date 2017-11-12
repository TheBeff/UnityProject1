using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMovement : MonoBehaviour {

	Rigidbody2D rb;

	private bool isMoving = false;

	public float jiggle_offset = 0.4f;

	private Vector2 startPosition;
	private Vector2 newVelocity;

	public float gloveSpeed;
	public float gloveScale;


	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();
		startPosition = this.transform.position;//new Vector2 (0, -3.6f);
	}
	
	void Update () {

		moveGlove ();
		scaleGlove ();

	}

	//basic WASD controls

	void moveGlove(){

		Vector2 newVelocity = new Vector2 (0, 0);

		isMoving = false;

		if(Input.GetKey(KeyCode.S)){
			isMoving = true;
			newVelocity += new Vector2(0, -1 * gloveSpeed);
		}
		if(Input.GetKey(KeyCode.W)){
			isMoving = true;
			newVelocity += new Vector2(0, gloveSpeed);
		}

		if(Input.GetKey(KeyCode.A)){
			isMoving = true;
			newVelocity += new Vector2(-1 * gloveSpeed, 0);
		}

		if (Input.GetKey(KeyCode.D)) {
			isMoving = true;
			newVelocity += new Vector2 (gloveSpeed, 0);
		} 

		rb.velocity = newVelocity;

		if (!isMoving) {
			resetGlove ();
		}
	}

	void scaleGlove(){
		if (rb.velocity.y > 0) transform.localScale += new Vector3 (gloveScale, gloveScale, 0);
		if (rb.velocity.y < 0) transform.localScale -= new Vector3 (gloveScale, gloveScale, 0);

	}

	//this function returns the glove to the starting position when not moving

	void resetGlove(){
		if (rb.position != startPosition) {
			Debug.Log ("trying to reset position");
			Vector2 newVelocity = new Vector2 (0, 0);
			if (rb.position.x < startPosition.x - jiggle_offset) 
				newVelocity += new Vector2(gloveSpeed, 0);
			if (rb.position.x > startPosition.x + jiggle_offset) 
				newVelocity += new Vector2(-gloveSpeed, 0);
			if (rb.position.y < startPosition.y - jiggle_offset) 
				newVelocity += new Vector2(0, gloveSpeed);
			if (rb.position.y > startPosition.y + jiggle_offset) 
				newVelocity += new Vector2(0, -gloveSpeed);

			rb.velocity = newVelocity;
		}
	}

}
