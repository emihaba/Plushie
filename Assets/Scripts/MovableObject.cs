using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

	public Vector3 targetPosition;
	public float transitionSpeed = 10.0f;

	void Awake()
	{
		targetPosition = transform.position;
	}

	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);
	}


}
