using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	private GameObject score;
	private Text scoreText;
	private SpawnerScript spawner;

	private GameObject health;
	private Text healthText;
	private GloveHealth gloveHealth;


	// Use this for initialization
	void Start () {
		intro = true;
		gameStarted = false;
		gameOver = false;

		musicTracks = GetComponents<AudioSource> ();
		soundtrack = musicTracks[0];
		theme = musicTracks [1];
		introMusicPlayed = false;

		score = GameObject.Find ("Score");
		scoreText = score.GetComponent<Text> ();
		spawner = GameObject.Find ("EnemySpawner").GetComponent<SpawnerScript> ();
		health = GameObject.Find ("Health");
		healthText = health.GetComponent<Text> ();
		gloveHealth = GameObject.Find ("glove").GetComponent<GloveHealth> ();

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

		scoreText.text = "BOB LEVEL: " + (spawner.level + 1);
		healthText.text = "FREDDIE HP: " + (gloveHealth.health);

	}
}
