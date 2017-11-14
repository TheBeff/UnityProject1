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
		deadBob = false;
		timeToBob = timer;
	}
	
	// Update is called once per frame
	void Update () {

		if (deadBob) {
			Debug.Log ("bob is dead");
			timer -= Time.deltaTime;
			Debug.Log ("time until bob: " + timer);

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
