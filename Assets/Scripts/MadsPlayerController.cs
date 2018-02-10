using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadsPlayerController : MonoBehaviour {

	//Key inputs
	public KeyCode jumpKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	//Unity components
	Rigidbody2D rb;
	RaycastCollisionChecks colInfo;

	//Physics variables - We set these
	private float maxJumpHeight = 5;					// If this could be in actual unity units somehow, that would be great
	private float minJumpHeight = 1;					// If this could be in actual unity units somehow, that would be great
	private float timeToJumpApex = 0.5f; 					// This is in actual seconds
	private float maxMovespeed = 10;					// If this could be in actual unity units per second somehow, that would be great
	private float accelerationTime = 0.1f;				// This is in actual seconds
	private float deccelerationTime = 0.1f;				// This is in actual seconds
	private float turnTime = 0.1f;						// This is in actual seconds

	//Physics variables - These get set for us
	private float gravity;
	private float maxJumpVelocity;
	private float minJumpVelocity;
	private float acceleration;
	private float decceleration;
	private float turnAcceleration;

	//Physics variables - State variables
	float leftSpeed = 0.0f;
	float rightSpeed = 0.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		colInfo = GetComponent<RaycastCollisionChecks> ();
		SetupMoveAndJumpSpeed ();
	}
	
	// Update is called once per frame
	void Update () {

		Jumping ();	
		HorizontalSpeed ();

		//Debug.Log (rb.velocity.x + " " + rb.velocity.y);
	}

	void Jumping(){
		//Setting the initial jump velocity
		if(Input.GetKey (jumpKey)){
			if(colInfo.bot){
				rb.velocity = new Vector2 (rb.velocity.x, 0);
				rb.velocity += new Vector2 (0, maxJumpVelocity);	
			}
		} else {
			if(rb.velocity.y > minJumpVelocity){
				rb.velocity = new Vector2 (rb.velocity.x, minJumpVelocity);
			}
		}
		
		//Gravity
		rb.velocity -= new Vector2 (0, gravity * Time.deltaTime);
	}

	void HorizontalSpeed(){
		if(Input.GetKey (leftKey)){
			leftSpeed = acceleration * -1.0f * Time.deltaTime;
		} else {
			leftSpeed = decceleration * 1.0f * Time.deltaTime;
		}
			
		if(Input.GetKey (rightKey)){
			rightSpeed = acceleration * 1.0f * Time.deltaTime;
		} else {
			rightSpeed = decceleration * -1.0f * Time.deltaTime;
		}

		rb.velocity = new Vector2 (rightSpeed + leftSpeed, rb.velocity.y);
	}

	void SetupMoveAndJumpSpeed(){
		//Scale gravity and jump velocity to jumpHeights and timeToJumpApex
		gravity = (2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = gravity * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * gravity * minJumpHeight);

		//Scale acceleration values to the movespeed and wanted acceleration times
		acceleration = maxMovespeed / accelerationTime;
		decceleration = maxMovespeed / deccelerationTime;
		turnAcceleration = maxMovespeed / turnTime;

		//Debug.Log ("Acelleration: " + acceleration + ", Decelleration: " + decceleration + ", Turn Acceleration: " + turnAcceleration + ", Gravity: " + gravity + ", Min jump velocity: " + minJumpVelocity + ", Max jump velocity: " + maxJumpVelocity);
	}
}
