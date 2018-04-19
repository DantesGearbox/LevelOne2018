using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathShake : MonoBehaviour {

	public float shakeAngle = 15.0f;
	public float shakeFrequency = 0.2f;

	private float duration = 5.0f;
	private float timer = 0.0f;
	private bool shaking = false;

	public void StartShaking(float newDuration){
		duration = newDuration;
		shaking = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(shaking){
			timer += Time.deltaTime;
			if(timer > duration){
				shaking = false;
				timer = 0.0f;
			}


			float angle = Mathf.PingPong (Time.time * (1/shakeFrequency), shakeAngle * 2);
			transform.localRotation = Quaternion.Euler (new Vector3(0, 0, angle-shakeAngle));


		}
	}
}
