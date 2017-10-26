using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	GameObject gameManager;
	float speed;
	private float newVerticalPosition;
	private float resetVerticalPosition;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager");
		speed = gameManager.GetComponent<GameManager> ().backgroundScrollSpeed;

		newVerticalPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		newVerticalPosition -= speed;

		if (transform.position.y <= -17.88) {
			transform.position = new Vector3 (0, 26.65f, 0);
		} else {
			transform.position = new Vector3 (0, newVerticalPosition, 0);
		}


	}
}
