using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	private Animator animator;
	private MadsPlayerController player;
	private RaycastCollisionChecks colInfo;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		player = GetComponent<MadsPlayerController> ();
		colInfo = GetComponent<RaycastCollisionChecks> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (colInfo.bot) {
			if (rb.velocity.x != 0.0f) {
				animator.Play ("RatWalkingAnimation");
			} else {
				animator.Play ("RatIdleAnimation");
			}	
		} else {
			if (rb.velocity.y > 0.0f) {
				animator.Play ("RatJumpingAnimation");
			} else {
				animator.Play ("RatFallingAnimation");
			}
		}

		// Sprite direction
		if (!player.playerDead) {
			if (player.GetInputDirection () > 0.1f) {
				transform.localRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
			} else {
				transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
			}
		}
	}
}
