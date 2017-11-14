using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script controls the scrolling background

public class ScrollingObject : MonoBehaviour {

	GameObject gameManager;
	float speed;
	private float newVerticalPosition;
	private float resetVerticalPosition;

	void Start () {

		//fetch the background scroll speed
		gameManager = GameObject.Find ("GameManager");
		speed = gameManager.GetComponent<GameManager> ().backgroundScrollSpeed;

		//create a copy of the scrolling object's current vertical position
		newVerticalPosition = transform.position.y;
	}

	void Update () {

		//subtract the speed from that copy
		newVerticalPosition -= speed;

		//if the background falls below the game screen, put it back on top of it
		//otherwise, set it to the new position
		if (transform.position.y <= -17.88f) {
			transform.position = new Vector3 (0, 26.65f, 0);
			newVerticalPosition = transform.position.y;
		} else {
			transform.position = new Vector3 (0, newVerticalPosition, 0);
		}


	}
}
