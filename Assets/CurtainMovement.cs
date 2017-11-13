using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMovement : MonoBehaviour {

	public float curtainSpeed;
	bool intro;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		intro = GameObject.Find ("GameManager").GetComponent<GameManager> ().intro;
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space))
			intro = false;

		if (!intro)
			rb.velocity += new Vector2 (0, curtainSpeed);

		if (transform.position.y > 12)
			Destroy (gameObject);
	}
}
