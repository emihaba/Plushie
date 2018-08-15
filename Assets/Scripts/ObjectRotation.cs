using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{

	public float rotationSpeed = 10;
	public float snapSpeed = 10;
	bool isRotating = false;
	public bool isSnaping = false;
	float[] snapAngles = { 0, 90, 180, 270 };
	Quaternion snapRotation;

	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray) == false)
			{
				isRotating = true;
				isSnaping = false;
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			if (isRotating)
			{
				isSnaping = true;
				SnapToClosestAngle();
			}
			isRotating = false;
		}


		if (isRotating)
		{

			float rotateX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
			transform.Rotate(Vector3.up, -rotateX);
		}

		if (isSnaping)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, snapRotation, snapSpeed * Time.deltaTime);
			if (Quaternion.Angle(transform.rotation, snapRotation) < float.Epsilon)
			{
				isSnaping = false;
			}
		}


	}

	private void SnapToClosestAngle()
	{
		Quaternion snapTarget = Quaternion.AngleAxis(snapAngles[0], Vector3.up);

		for (int i = 1; i < snapAngles.Length; i++)
		{
			Quaternion currentRotation = Quaternion.AngleAxis(snapAngles[i], Vector3.up);
			if (Quaternion.Angle(transform.rotation, currentRotation) < Quaternion.Angle(transform.rotation, snapTarget))
			{
				snapTarget = currentRotation;
			}
		}

		snapRotation = snapTarget;
	}
}
