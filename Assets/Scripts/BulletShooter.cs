using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour {

	private MadsPlayerController player;
	public KeyCode shootKey;
	public GameObject bulletPrefab;

	private float shotCooldown = 0.1f;
	private float shotTimer = 0.0f;
	public bool canShoot = true;

	// Use this for initialization
	void Start () {
		player = GetComponent<MadsPlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(!canShoot){
			shotTimer += Time.deltaTime;
			if(shotTimer > shotCooldown){
				canShoot = true;
				shotTimer = 0.0f;
			}
		}

		if(Input.GetKey (shootKey) && canShoot){
			canShoot = false;
			GameObject bulletObject = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
			Bullet bullet = bulletObject.GetComponent<Bullet> ();
			bullet.fire (player.GetInputDirection ());
		}
	}
}
