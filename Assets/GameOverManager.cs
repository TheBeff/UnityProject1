using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	//variables needed for making sure the user types two 'r's to reset
	float maxDelay = 0.5f;
	bool resetReady = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r")){
			if (resetReady)
				Reset ();
			else
				PrepareReset (true);
		}
	}

	void Reset(){
		resetReady = false;
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
