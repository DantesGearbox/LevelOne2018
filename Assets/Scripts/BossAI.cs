using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour {

	private FireballShooter fireballShooter;
	private FlashColor flashColor;
	private DeathShake deathShaker;
	private Animator animator;
	public Collider2D playerCollider;
	public Collider2D bossCollider;

	private int bossHealth = 400;

	private float deathAnimationTimer = 0.0f;
	private float deathAnimationLength = 5.0f;
	private bool bossDead = false;

	private float attackTimeLength = 5.0f;
	private float pauseTimeLength = 5.0f;
	private int amountOfAttacks = 1;
	private bool attacking = false;
	private float pauseTimer = 0.0f;
	private float attackTimer = 0.0f;
	private int attackNumber = 0;

	public BoxCollider2D[] stageColliders;
	public enum Stages {UpperLeft, LowerLeft, UpperMiddle, LowerMiddle, UpperRight, LowerRight};
	public Stages playerStage;

	// Use this for initialization
	void Start () {
		fireballShooter = GetComponent<FireballShooter> ();
		flashColor = GetComponent<FlashColor> ();
		deathShaker = GetComponent<DeathShake> ();
		animator = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.gameObject.tag == "Player"){
			Debug.Log ("Player");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {	
		if (bossCollider.IsTouching (other)) {

			if (other.tag == "Bullet") {

				bossHealth--;

				Destroy (other.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		for(int i = 0; i < stageColliders.Length; i++){

			if(stageColliders [i].IsTouching (playerCollider)){

				if(i == 0){
					playerStage = Stages.UpperLeft;
				}
				if(i == 1){
					playerStage = Stages.LowerLeft;
				}
				if(i == 2){
					playerStage = Stages.LowerMiddle;
				}
				if(i == 3){
					playerStage = Stages.UpperMiddle;
				}
				if(i == 4){
					playerStage = Stages.UpperRight;
				}
				if(i == 5){
					playerStage = Stages.LowerRight;
				}
			}
		}

		if(!attacking){
			pauseTimer += Time.deltaTime;
			if(pauseTimer > pauseTimeLength){ //ATTACK STARTING
				animator.Play ("PickleFireball");
				//animator.Play ("NewFireballAnimation");
				attacking = true;
				pauseTimer = 0.0f;

				//What attack are we doing?
				fireballShooter.StartFireball (amountOfAttacks % 3);
			}
		} else {
			attackTimer += Time.deltaTime;
			if(attackTimer > attackTimeLength){ //ATTACK ENDING
				animator.Play ("PickleIdleAnimation");
				attacking = false;
				attackTimer = 0.0f;

				//What attack are we stopping?
				fireballShooter.StopFireball (amountOfAttacks % 3);

				amountOfAttacks++;
			}
		}

		if(bossHealth == 0){

			bossDead = true;
			flashColor.StartSwicthing ();
			deathShaker.StartShaking (deathAnimationLength);
			animator.Play ("PickleDead");
		}

		if(bossDead){
			deathAnimationTimer += Time.deltaTime;

			if(deathAnimationTimer > deathAnimationLength){
				SceneManager.LoadScene ("Victory");
				Debug.Log ("Death Animation Over");
			}
		}
	}
}
