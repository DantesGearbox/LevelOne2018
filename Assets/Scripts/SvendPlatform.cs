using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvendPlatform : MonoBehaviour {
	//Unity components
	Rigidbody2D rb;

	public float movespeed = 10.0f;
	public bool xaxis = true;
	public Vector2 endpoint;


	private Transform transform;
	private Transform scale;
	private Vector2 startpoint;

	private bool direction;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startpoint = rb.position;
		transform = rb.transform;

		scale = GetComponent<Transform>();

		direction = true;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.position);

		if(xaxis) {
			if(direction) {
				//Debug.Log("YEEEES");
				transform.Translate(movespeed * Time.deltaTime, 0, 0);
				if(transform.position.x > endpoint.x) {
					direction = false;
				}

			} else {
				//Debug.Log("NOOOO");
				transform.Translate(-movespeed * Time.deltaTime, 0, 0);
				if(transform.position.x < startpoint.x) {
					direction = true;
				}
			}
		} else {
			if(direction) {
				//Debug.Log("YEEEES");
				transform.Translate(0, movespeed * Time.deltaTime, 0);
				if(transform.position.y > endpoint.y) {
					direction = false;
				}

			} else {
				//Debug.Log("NOOOO");
				transform.Translate(0, -movespeed * Time.deltaTime, 0);
				if(transform.position.y < startpoint.y) {
					direction = true;
				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if(other.transform.tag == "Player")
		{
			other.transform.parent = transform;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if(other.transform.tag == "Player")
		{
			//Debug.Log("COLL EXIT");
			other.transform.parent = null;
		}
	}
}
