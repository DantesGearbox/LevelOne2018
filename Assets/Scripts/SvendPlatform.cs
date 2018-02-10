using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvendPlatform : MonoBehaviour {
	//Unity components
	Rigidbody2D rb;

	public float movespeed = 10.0f;
	public Vector2 endpoint;

	private Transform transform;
	private Transform scale;
	private Vector2 startpoint;

	private bool direction;
	private float distance;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startpoint = rb.position;
		distance = Vector2.Distance(startpoint, endpoint);
		transform = rb.transform;

		scale = GetComponent<Transform>();

		direction = true;
	}

	// Update is called once per frame
	void Update () {

		if(direction) {
			transform.Translate(movespeed * Time.deltaTime * (endpoint.x - startpoint.x) / distance,
													movespeed * Time.deltaTime * (endpoint.y - startpoint.y) / distance,
													0);
			if(Vector2.Distance(transform.position, endpoint) < 0.1) {
				direction = false;
			}
		} else {
			transform.Translate(-movespeed * Time.deltaTime * (endpoint.x - startpoint.x) / distance,
													-movespeed * Time.deltaTime * (endpoint.y - startpoint.y) / distance,
													0);
			if(Vector2.Distance(transform.position, startpoint) < 0.1) {
				direction = true;
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
			other.transform.parent = null;
		}
	}
}
