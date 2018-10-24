using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public List<Tile> walkableTiles = new List<Tile>();
	GameObject[] tiles;

	Stack<Tile> path = new Stack<Tile>();
	Tile currentTile;

	public float jumpHeight = 1;
	public float moveSpeed = 2;

	Vector3 velocity = new Vector3();
	Vector3 headingDirection = new Vector3();

	float halfHeight = 0;

	public LayerMask layerMask = 9;

	void Start()
	{
		tiles = GameObject.FindGameObjectsWithTag("Tile");

		halfHeight = GetComponent<Collider>().bounds.extents.y;
	}

	void Update()
	{
		FindWalkableTiles();
		CheckMouse();
		Move();
	}

	public void GetCurrentTile()
	{
		currentTile = GetTargetTile(gameObject);
		currentTile.current = true;

	}

	public Tile GetTargetTile(GameObject target)
	{
		RaycastHit hit;
		Tile tile = null;

		if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1000, layerMask))
		{
			tile = hit.collider.GetComponent<Tile>();
		}

		return tile;

	}

	public void ComputeNeighbours()
	{
		foreach (GameObject tile in tiles)
		{
			Tile t = tile.GetComponent<Tile>();
			t.FindNeighbours(jumpHeight);
		}
	}

	public void FindWalkableTiles()
	{
		ComputeNeighbours();
		GetCurrentTile();

		Queue<Tile> process = new Queue<Tile>();

		process.Enqueue(currentTile);
		currentTile.visited = true;

		while (process.Count > 0)
		{
			Tile t = process.Dequeue();

			walkableTiles.Add(t);
			t.walkable = true;

			foreach (Tile tile in t.neighbours)
			{
				if (!tile.visited)
				{
					tile.parent = t;
					tile.visited = true;
					process.Enqueue(tile);
				}
			}
		}
	}

	void CheckMouse()
	{

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 1000, layerMask))
			{

				if (hit.collider.tag == "Tile")
				{
					Tile t = hit.collider.GetComponent<Tile>();

					if (t.walkable)
					{
						MoveToTile(t);
					}
				}
			}
		}




	}

	void MoveToTile(Tile targetTile)
	{

		path.Clear();
		targetTile.target = true;

		Tile next = targetTile;

		while (next != null)
		{
			path.Push(next);
			next = next.parent;
		}
	}

	void Move()
	{
		if (path.Count > 0)
		{
			Tile t = path.Peek();
			Vector3 targetPosition = t.transform.position;

			targetPosition.y += halfHeight;

			if (Vector3.Distance(targetPosition, transform.position) >= 0.05f)
			{
				CalculateHeading(targetPosition);
				SetVelocity();

				transform.forward = headingDirection;
				transform.position += velocity * Time.deltaTime;

			}
			else
			{
				transform.position = targetPosition;
				path.Pop();
			}
		}
		else
		{
			currentTile.current = false;
			currentTile = null;
		}
	}

	void CalculateHeading(Vector3 targetPosition)
	{
		headingDirection = targetPosition - transform.position;
		headingDirection.Normalize();
	}

	void SetVelocity()
	{
		velocity = headingDirection * moveSpeed;
	}

}
