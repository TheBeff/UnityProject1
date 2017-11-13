using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health;
	public GameObject explosion;
	private Vector3 localScale;
	private Vector3 currentPosition;
	private bool exploded = false;
	int level;

	// Use this for initialization
	void Start () {
		level = GameObject.Find ("EnemySpawner").GetComponent<SpawnerScript> ().level;
		health += level;  
	}
	
	// Update is called once per frame
	void Update () {

		currentPosition = transform.position;

		if (health <= 0) {
//			localScale.x++;
//			localScale.y++;
//			transform.localScale = localScale;
			Destroy (gameObject, 1);
			if (!exploded) createExplosion ();
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Player")) {
			health -= 1;
		}
	}

	void createExplosion(){
		GameObject newExplosion = Instantiate(explosion, currentPosition, Quaternion.identity) as GameObject;
		exploded = true;
	}
}
