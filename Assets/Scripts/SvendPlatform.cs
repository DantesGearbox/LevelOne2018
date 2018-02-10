using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvendPlatform : MonoBehaviour {
	//Unity components
	Rigidbody2D rb;

	public float movespeed = 10.0f;

	private Transform transform;

	private bool direction;

	private Vector2 startpoint;
	private Vector2 endpoint = new Vector2(0.0f, 0.0f);
	private Vector2 position;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		startpoint = rb.position;
		transform = rb.transform;

		direction = true;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(transform.position);
		if(direction) {
			Debug.Log("YEEEES");
			transform.Translate(movespeed * Time.deltaTime, 0, 0);
			if(transform.position.x > endpoint.x) {
				direction = false;
			}

		} else {
			Debug.Log("NOOOO");
			transform.Translate(-movespeed * Time.deltaTime, 0, 0);
			if(transform.position.x < startpoint.x) {
				direction = true;
			}
		}
	}
}
