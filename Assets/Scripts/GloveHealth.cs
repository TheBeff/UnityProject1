using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveHealth : MonoBehaviour {

	public int health;
	GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			gameManager.gameOver = true;
		}
	}
}
