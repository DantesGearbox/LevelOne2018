using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody2D rb;
	private float speed = 20.0f;

	void OnTriggerEnter2D(Collider2D other) {	

		if(other.tag == "Obstacles"){
			Destroy (gameObject);	
		}
	}

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void fire(float direction){
		rb.velocity = new Vector2 (speed * direction, 0);
	}
}
