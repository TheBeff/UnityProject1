using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	float maxDelay = 0.5f;
	bool resetReady = false;

	AudioSource theme;

	// Use this for initialization
	void Start () {
		theme = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		//checks to make sure the player types TWO 'r's not just one to reset
		if (Input.GetKeyDown("r")){
			if (resetReady)
				Reset ();
			else
				PrepareReset (true);
		}
	}

	void Reset(){
		resetReady = false;
		theme.Stop ();
		SceneManager.LoadScene ("ProjectGreenGlove");
	}

	void PrepareReset(bool getReady){
		CancelInvoke ("CancelReset");
		Invoke ("CancelReset", maxDelay);
		resetReady = true;
	}

	void CancelInvoke(){
		resetReady = false;
	}
}
