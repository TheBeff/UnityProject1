using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHealth : MonoBehaviour {

	public int health;
	bool gameOver;
	// Use this for initialization
	void Start () {
		gameOver = GameObject.Find ("GameManager").GetComponent<GameManager>().gameOver;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			gameOver = true;
		}
	}
}
