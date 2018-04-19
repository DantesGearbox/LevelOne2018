using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	Rigidbody2D rb;
	private float speed = -10.0f;

	private float timer = 0.0f;
	private float timeToDeath = 10.0f;

	void OnTriggerEnter2D(Collider2D other) {	
		if(other.tag == "Player"){

			//Debug.Log ("Hit Player");

			//Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){

		timer += Time.deltaTime;
		if(timer > timeToDeath){
			Destroy (gameObject);
		}

		rb.velocity = new Vector2 (speed, 0);
	}
}
