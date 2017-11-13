using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public GameObject bobFab;
	Vector3 position; 
	public int level; 
	bool intro;
	GameObject currentBob; 

	// Use this for initialization
	void Start () {
		intro = GameObject.Find ("GameManager").GetComponent<GameManager> ().intro;
		level = 0;
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!currentBob) {
			level++;
			GameObject newBob = Instantiate (bobFab, position, Quaternion.identity) as GameObject;
			currentBob = newBob;
		}

	}
}
