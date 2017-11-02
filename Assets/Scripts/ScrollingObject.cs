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

		//fetch the background scroll speed
		gameManager = GameObject.Find ("GameManager");
		speed = gameManager.GetComponent<GameManager> ().backgroundScrollSpeed;

		//create a copy of the scrolling object's current vertical position
		newVerticalPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		//subtract the speed from that copy
		newVerticalPosition -= speed;

		//if the background falls below the game screen, put it back on top of it
		//otherwise, set it to the new position
		if (transform.position.y <= -17.88) {
			transform.position = new Vector3 (0, 26.65f, 0);
			newVerticalPosition = transform.position.y;
		} else {
			transform.position = new Vector3 (0, newVerticalPosition, 0);
		}


	}
}
