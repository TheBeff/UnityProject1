using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float backgroundScrollSpeed;
	public float safeZoneMax;

	public bool intro;
	public bool gameStarted;
	public bool gameOver;

	AudioSource soundtrack;

	// Use this for initialization
	void Start () {
		intro = true;
		gameStarted = false;
		gameOver = false;
		soundtrack = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!intro && gameStarted) {
			gameStarted = false;
			soundtrack.Play ();
		}
			
	}
}
