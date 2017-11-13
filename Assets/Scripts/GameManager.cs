using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float backgroundScrollSpeed;
	public float safeZoneMax;

	public bool intro;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		intro = true;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
