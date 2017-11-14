using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float backgroundScrollSpeed;
	public float safeZoneMax;

	public bool intro;
	public bool gameStarted;
	public bool gameOver;
	private bool introMusicPlayed;

	AudioSource[] musicTracks;
	AudioSource soundtrack;
	AudioSource theme;


	// Use this for initialization
	void Start () {
		intro = true;
		gameStarted = false;
		gameOver = false;
		musicTracks = GetComponents<AudioSource> ();
		soundtrack = musicTracks[0];
		theme = musicTracks [1];
		introMusicPlayed = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (intro && !introMusicPlayed) {
			theme.PlayOneShot (theme.clip);
			introMusicPlayed = true;
		}
			
		if (!intro && gameStarted) {
			gameStarted = false;
			theme.Stop ();
			soundtrack.Play ();
		}

		if (gameOver)
			SceneManager.LoadScene ("GameOver");
	}
}
