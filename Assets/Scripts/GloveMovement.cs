using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveMovement : MonoBehaviour {

	Rigidbody2D rb;

	private bool isMoving = false;
	private bool isPunching = false;

	public float jiggle_offset = 0.4f;

	private Vector3 startScale;
	private Vector2 startPosition;
	private Vector2 newVelocity;

	public float punchSpeed;
	public float gloveSpeed;
	public float gloveScale;
	public float gloveYMin;
	public float gloveYMax;

	public GameObject curtain;

	private bool cantPunch = false;


	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();
		startScale = transform.localScale;
		startPosition = rb.position;//new Vector2 (0, -3.6f);
	}
	
	void Update () {

		if (rb.position.y > gloveYMax || rb.position.y < gloveYMin) {
			resetGlove ();
		} else if (!curtain) {
			moveGlove ();
			scaleGlove ();
		}

	}

	//glove can move left or right with A or D, and will reset to starting position when key is lifted
	//when W is pushed, the glove will punch up quickly

	void moveGlove(){

		newVelocity = new Vector2 (0, 0);

		isMoving = false;

		if(Input.GetKey(KeyCode.W) && !isPunching && !cantPunch){
			isMoving = true;
			isPunching = true;
			newVelocity += new Vector2(0, punchSpeed);

		}

		if(Input.GetKey(KeyCode.A)){
			isMoving = true;
			newVelocity += new Vector2(-1 * gloveSpeed, 0);
		}

		if (Input.GetKey(KeyCode.D)) {
			isMoving = true;
			newVelocity += new Vector2 (gloveSpeed, 0);
		} 

		if ((Input.GetKeyUp(KeyCode.W)) || (rb.position.y >= 0))
			cantPunch = true;

		if (rb.position.y <= startPosition.y+1)
			cantPunch = false;
			
		rb.velocity = newVelocity;

		resetCheck ();

		if (!isMoving && !isPunching) {
			Debug.Log ("Resetting.");
			resetGlove ();
		}

	}

	void resetCheck() {
		if (rb.position.y >= startPosition.y) {
			Debug.Log ("marking unpunch");
			isPunching = false;
		}
	}

	//the glove grows in scale as it goes up the Y axis
	void scaleGlove(){
		if (rb.velocity.y > 0) 
			transform.localScale += new Vector3 (gloveScale, gloveScale, 0);
		if (rb.velocity.y < 0 && transform.localScale.y > startScale.y) 
			transform.localScale -= new Vector3 (gloveScale, gloveScale, 0);
		if (rb.velocity.y == 0)
			transform.localScale = startScale;

	}

	//this function returns the glove to the starting position when not moving

	void resetGlove(){
		if (rb.position != startPosition) {
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
