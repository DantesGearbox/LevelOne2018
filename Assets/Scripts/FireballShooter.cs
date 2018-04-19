using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour {

	public GameObject fireballPrefab;

	private float fireball1ShotCooldown = 0.5f;
	private float fireball1ShotTimer = 0.0f;
	private bool fireball1 = false;
	private float fireball1Height = 2.0f;

	private float fireball2ShotCooldown = 0.5f;
	private float fireball2ShotTimer = 0.0f;
	private bool fireball2 = false;
	private float fireball2Height = -2.0f;

	private float fireball3ShotCooldown = 0.5f;
	private float fireball3ShotTimer = 0.0f;
	private bool fireball3 = false;
	private float fireball3Height = 0.0f;

	private int amountOfRounds = 0;

	// Update is called once per frame
	void Update () {

		if(fireball1){
			fireball1ShotTimer += Time.deltaTime;
			if(fireball1ShotTimer > fireball1ShotCooldown){
				fireball1ShotTimer = 0.0f;

				GameObject fireballObject = Instantiate (fireballPrefab, transform.position, transform.rotation) as GameObject;
				fireballObject.transform.localPosition = new Vector3 (10, fireball1Height, 0);
			}
		}

		if(fireball2){
			fireball2ShotTimer += Time.deltaTime;
			if(fireball2ShotTimer > fireball2ShotCooldown){
				fireball2ShotTimer = 0.0f;

				GameObject fireballObject = Instantiate (fireballPrefab, transform.position, transform.rotation) as GameObject;
				fireballObject.transform.localPosition = new Vector3 (10, fireball2Height, 0);
			}
		}

		if(fireball3){
			fireball3ShotTimer += Time.deltaTime;
			if(fireball3ShotTimer > fireball3ShotCooldown){
				fireball3ShotTimer = 0.0f;

				GameObject fireballObject = Instantiate (fireballPrefab, transform.position, transform.rotation) as GameObject;
				fireballObject.transform.localPosition = new Vector3 (10, fireball3Height, 0);
				fireball3Height = Mathf.PingPong (Time.time, 6.0f) - 3.0f;
			}
		}
	}

	public void StartFireball(int type){
		if(type == 0){
			fireball1 = true;
		}
		if(type == 1){
			fireball2 = true;
		}
		if(type == 2){
			fireball3 = true;
		}

		amountOfRounds++;
	}

	public void StopFireball(int type){
		if(type == 0){
			fireball1 = false;
		}
		if(type == 1){
			fireball2 = false;
		}
		if(type == 2){
			fireball3 = false;
		}
	}
}