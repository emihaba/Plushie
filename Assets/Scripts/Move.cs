using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	public LayerMask layerMask;
	public MovableObject movedObject;

	bool IsMoving
	{
		get
		{
			return movedObject != null;
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			movedObject = null;
		}

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				movedObject = hit.collider.GetComponent<MovableObject>();
			}
		}

		if (IsMoving)
		{

			Vector3 tilePosition;

			if (FindNearestTilePosition(out tilePosition))
			{
				if (CanMoveToPosition(tilePosition))
				{
					MoveToPosition(tilePosition);
				}


			}

		}


	}

	bool FindNearestTilePosition(out Vector3 tilePosition)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 1000, layerMask))
		{
			tilePosition = hit.collider.transform.position;

			return true;
		}

		tilePosition = Vector3.zero;
		return false;

	}

	bool CanMoveToPosition(Vector3 tilePosition)
	{
		RaycastHit hit;
		Vector3 movingDirection = tilePosition - movedObject.transform.position;

		return !movedObject.GetComponent<Rigidbody>().SweepTest(movingDirection.normalized, out hit, movingDirection.magnitude, QueryTriggerInteraction.Ignore);

	}

	void MoveToPosition(Vector3 tilePosition)
	{
		movedObject.targetPosition = tilePosition;

	}

}
