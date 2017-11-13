using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainMovement : MonoBehaviour {

	public float curtainSpeed;
	GameManager gameManager;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			gameManager.intro = false;
			gameManager.gameStarted = true;
		}

		if (!gameManager.intro)
			rb.velocity += new Vector2 (0, curtainSpeed);

		if (transform.position.y > 12)
			Destroy (gameObject);
	}
}
