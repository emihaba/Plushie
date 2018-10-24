using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{

	public float rotationSpeed = 40;
	public float bounceSpeed = 2;
	public float bounceHeight = 0.2f;

	private Vector3 startPosition;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight, transform.position.z);
		transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

	}
}
