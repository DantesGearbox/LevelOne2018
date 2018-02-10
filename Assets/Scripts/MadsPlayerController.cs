using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadsPlayerController : MonoBehaviour {

	//Key inputs
	public KeyCode jumpButton;
	public KeyCode leftButton;
	public KeyCode rightButton;

	//Physics variables
	//We set these
	private float maxJumpHeight = 1;					// If this could be in actual unity units somehow, that would be great
	private float minJumpHeight = 1;					// If this could be in actual unity units somehow, that would be great
	private float timeToJumpApex = 1; 					// This is in actual seconds
	private float maxMovespeed = 1;						// If this could be in actual unity units per second somehow, that would be great
	private float accelerationTime = 0.1f;				// This is in actual seconds
	private float deccelerationTime = 0.1f;				// This is in actual seconds
	private float turnTime = 0.1f;						// This is in actual seconds

	//These get set for us
	private float gravity;
	private float maxJumpVelocity;
	private float minJumpVelocity;
	private float acceleration;
	private float decceleration;
	private float turnAcceleration;


	// Use this for initialization
	void Start () {
		SetupMoveAndJumpSpeed ();
	}
	
	// Update is called once per frame
	void Update () {
		
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
