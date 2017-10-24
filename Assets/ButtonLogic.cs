using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //need to add to mess with scenes

public class ButtonLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		//load the main game scene
		SceneManager.LoadScene ("TempProject");
	}
}
