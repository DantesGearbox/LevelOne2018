using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCollisionChecks : MonoBehaviour {

	private struct RaycastOrigins
	{
		public Vector2 botLeft, botRight, topLeft, topRight;
	}

	public struct CollisionInformation
	{
		public bool left, right, top, bot;
	}

	public LayerMask collisionMask;
	private BoxCollider2D bc;
	private RaycastOrigins raycastOrigins;
	private CollisionInformation colInfo;

	private float rayLengthVertical = 0.1f;
	private float rayLengthHorizontal = 0.1f;
	private const float dstBetweenRays = .15f;

	private int horizontalRayCount;
	private int verticalRayCount;
	private float horizontalRaySpacing;
	private float verticalRaySpacing;

	public bool bot, top, left, right;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update (){

		bot = colInfo.bot;
		left = colInfo.left;
		right = colInfo.right;
		top = colInfo.top;

		UpdateRaycastOrigins();
		CalculateRaySpacing ();
		UpdateCollisions();
	}

	private void UpdateRaycastOrigins(){
		Bounds bounds = bc.bounds;

		raycastOrigins.botLeft = new Vector2(bounds.min.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
		raycastOrigins.botRight = new Vector2(bounds.max.x, bounds.min.y);
		raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
	}

	public void CalculateRaySpacing() {
		Bounds bounds = bc.bounds;

		float boundsWidth = bounds.size.x;
		float boundsHeight = bounds.size.y;

		horizontalRayCount = Mathf.RoundToInt (boundsHeight / dstBetweenRays);
		verticalRayCount = Mathf.RoundToInt (boundsWidth / dstBetweenRays);

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x  / (verticalRayCount - 1);
	}

	private void UpdateCollisions(){

		VerticalCollisions (1.0f);
		VerticalCollisions (-1.0f);
		HorizontalCollisions (1.0f);
		HorizontalCollisions (-1.0f);
	}

	void VerticalCollisions(float direction) {
		float directionY = Mathf.Sign (direction);


		bool coll = false;
		for (int i = 0; i < verticalRayCount; i ++) {

			Vector2 rayOrigin = (directionY == -1.0f) ? raycastOrigins.botLeft : raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLengthVertical, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLengthVertical,Color.red);

			if (hit) {

				colInfo.bot = directionY == -1.0f;
				colInfo.top = directionY == 1.0f;
				coll = true;

			/*} else {
				if(direction == -1.0f){ colInfo.bot = false; }
				if(direction == 1.0f){ colInfo.top = false; }*/
			}
		}

		if(!coll){
			if(direction == -1.0f){ colInfo.bot = false; }
			if(direction == 1.0f){ colInfo.top = false; }
		}

	}

	void HorizontalCollisions(float direction) {
		float directionX = Mathf.Sign (direction);

		bool coll = false;
		for (int i = 0; i < horizontalRayCount; i ++) {
			Vector2 rayOrigin = (directionX == -1.0f) ? raycastOrigins.botLeft : raycastOrigins.botRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLengthHorizontal, collisionMask);

			Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLengthHorizontal, Color.red);

			if (hit) {
				colInfo.left = directionX == -1.0f;
				colInfo.right = directionX == 1.0f;
				coll = true;
			/*} else {
				if(direction == -1.0f){ colInfo.left = false; }
				if(direction == 1.0f){ colInfo.right = false; }*/
			}
		}

		if(coll){
			if(direction == -1.0f){ colInfo.left = false; }
			if(direction == 1.0f){ colInfo.right = false; }
		}
	}

	public CollisionInformation GetCollisionInformation(){
		return colInfo;
	}
}
