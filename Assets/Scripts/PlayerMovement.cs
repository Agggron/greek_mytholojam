using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
	private Rigidbody rb;
	private Vector3 movement;
	private int groundMask;
	private float cameraRayLength = 100.0f;

	void Awake() 
	{
		rb = GetComponent<Rigidbody> ();
		groundMask = LayerMask.GetMask ("Ground");
	}

	void FixedUpdate() 
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Move (horizontal, vertical);

		Turning ();
	}

	private void Move(float horizontal, float vertical) 
	{
		movement.Set (horizontal, 0.0f, vertical);

		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}

	private void Turning() 
	{
		Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit groundHit;

		if (Physics.Raycast (cameraRay, out groundHit, cameraRayLength, groundMask)) 
		{
			Vector3 playerToMouse = groundHit.point - transform.position;
			playerToMouse.y = 0.0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			rb.MoveRotation (newRotation);
		}
	}
}
