using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	public bool walkable = false;
	public bool current = false;
	public bool target = false;

	public List<Tile> neighbours = new List<Tile>();


	//BFS
	public bool visited = false;
	public Tile parent = null;

	//Highlight
	public Color highlightColor;
	Color baseColor;
	Color targetColor;
	new Renderer renderer;
	public float colorTransitionSpeed = 10;

	public LayerMask layerMask;


	// Use this for initialization
	void Awake()
	{
		renderer = GetComponentInChildren<Renderer>();
		baseColor = renderer.materials[1].color;
		targetColor = baseColor;
	}

	// Update is called once per frame
	void Update()
	{

		if (renderer.materials[1].color.Equals(targetColor) == false)
		{
			renderer.materials[1].color = Color.Lerp(renderer.materials[1].color, targetColor, colorTransitionSpeed * Time.deltaTime);
		}

	}

	public void Clear()
	{
		neighbours.Clear();

		walkable = false;
		current = false;
		target = false;
		visited = false;
		parent = null;
	}

	public void FindNeighbours(float jumpHeight)
	{
		Clear();

		CheckTile(Vector3.forward, jumpHeight);
		CheckTile(-Vector3.forward, jumpHeight);
		CheckTile(Vector3.right, jumpHeight);
		CheckTile(-Vector3.right, jumpHeight);

	}

	public void CheckTile(Vector3 direction, float jumpHeight)
	{
		Vector3 halfExtents = new Vector3(0.25f, (0.4f + jumpHeight) / 2, 0.25f);
		Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

		foreach (Collider collider in colliders)
		{
			Tile tile = collider.GetComponent<Tile>();

			if (tile != null)
			{
				RaycastHit hit;

				if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1000, layerMask))
				{
					neighbours.Add(tile);
				}
				else
				{
				}
			}
		}
	}

	public void Highlight()
	{

		targetColor = highlightColor;

	}

	public void Unhighlight()
	{
		targetColor = baseColor;
	}
}
