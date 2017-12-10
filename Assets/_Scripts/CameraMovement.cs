using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject playerForCamera;
	public Vector3 playerPosition;
	public Vector3 cameraPointPosition;
	public Vector3 offsetFromCameraPoint;

	public float boundaryRadius = 2.5f;
	public float leftBoundary;
	public float rightBoundary;
	public float topBoundary;
	public float bottomBoundary;
	public float movementSmoothing = 3.0f;

	void Start()
	{
		playerForCamera = GameObject.FindGameObjectWithTag ("PlayerLocationForCamera");
		if (playerForCamera == null) 
		{
			Debug.Log ("Cannot find PlayerLocationForCamera GameObject!");
		}

		playerPosition = playerForCamera.transform.position;
		cameraPointPosition = playerPosition;
		offsetFromCameraPoint = transform.position - cameraPointPosition;

		UpdateBoundaries ();
	}

	void UpdateBoundaries () 
	{
		leftBoundary = cameraPointPosition.x - boundaryRadius;
		rightBoundary = cameraPointPosition.x + boundaryRadius;
		topBoundary = cameraPointPosition.z + boundaryRadius;
		bottomBoundary = cameraPointPosition.z - boundaryRadius;
	}

	// With every player movement (during fixed update)
	void FixedUpdate () 
	{
	}

	// Only call this at the very end of each frame (after all movement is done)
	void LateUpdate()
	{
		playerPosition = playerForCamera.transform.position;

		// If player has moved past boundary, move the entire boundary box to accomodate this

		if (playerPosition.x < leftBoundary) 
		{
			// gameObject.transform.position = Vector3.Lerp(transform.position, playerPosition + offsetFromPlayer + new Vector3 (boundaryRadius, 0.0f, 0.0f), movementSmoothing * Time.deltaTime);
			cameraPointPosition.x = playerPosition.x + boundaryRadius;
		}

		if (playerPosition.x > rightBoundary) 
		{
			//gameObject.transform.position = Vector3.Lerp(transform.position, playerPosition + offsetFromPlayer + new Vector3 (-boundaryRadius, 0.0f, 0.0f), movementSmoothing * Time.deltaTime);
			cameraPointPosition.x = playerPosition.x - boundaryRadius;
		}

		if (playerPosition.z > topBoundary) 
		{
			//gameObject.transform.position = Vector3.Lerp(trancameraPointPosition.x = playerPosition.x + boundaryRadius;
			cameraPointPosition.z = playerPosition.z - boundaryRadius;
		}

		if (playerPosition.z < bottomBoundary) 
		{
			//gameObject.transform.position = Vector3.Lerp(transform.position, playerPosition + offsetFromPlayer + new Vector3 (0.0f, 0.0f, boundaryRadius), movementSmoothing * Time.deltaTime);
			cameraPointPosition.z = playerPosition.z + boundaryRadius;
		}
		UpdateBoundaries ();
		Debug.DrawLine(new Vector3 (leftBoundary, 0.5f, bottomBoundary), new Vector3 (leftBoundary, 0.5f, topBoundary), Color.white, 0.0f);
		Debug.DrawLine(new Vector3 (leftBoundary, 0.5f, topBoundary), new Vector3 (rightBoundary, 0.5f, topBoundary), Color.white, 0.0f);
		Debug.DrawLine(new Vector3 (rightBoundary, 0.5f, topBoundary), new Vector3 (rightBoundary, 0.5f, bottomBoundary), Color.white, 0.0f);
		Debug.DrawLine(new Vector3 (rightBoundary, 0.5f, bottomBoundary), new Vector3 (leftBoundary, 0.5f, bottomBoundary), Color.white, 0.0f);

		transform.position = cameraPointPosition + offsetFromCameraPoint;
	}
}
