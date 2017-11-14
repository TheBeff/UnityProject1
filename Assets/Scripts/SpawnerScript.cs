using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject bobFab;
	Vector3 position; 
	public int level; 
	GameManager gameManager;
	GameObject currentBob; 
	public bool deadBob;

	//these variables are used to time spawning new Bob
	public float timer;
	private float timeToBob;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		level = 0;
		position = transform.position;

		//bob is alive at the start
		deadBob = false;

		//save the timer so it can be reset
		timeToBob = timer;
	}
	
	// Update is called once per frame
	void Update () {

		//if bob is dead, start the spawn timer
		if (deadBob) {
			timer -= Time.deltaTime;

			//once it's run down, gain a level, make a new bob and reset the timer

			if (timer <= 0 && !currentBob) {
				level++;
				GameObject newBob = Instantiate (bobFab, position, Quaternion.identity) as GameObject;
				currentBob = newBob;
				deadBob = false;
				timer = timeToBob;
			}
		}


	}
}
