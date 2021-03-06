﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTarget : MonoBehaviour
{
	Tile currentlyHighlightedTile = null;

	public LayerMask layerMask;

	void Update()
	{


		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 1000, layerMask))
		{

			Tile tile = hit.collider.gameObject.GetComponent<Tile>();

			if (tile != null && tile.walkable)
			{
				if (currentlyHighlightedTile != tile)
				{
					if (currentlyHighlightedTile != null)
					{
						currentlyHighlightedTile.Unhighlight();
					}

					currentlyHighlightedTile = tile;
					tile.Highlight();
				}

			}
			else
			{
				if (currentlyHighlightedTile != null)
				{
					currentlyHighlightedTile.Unhighlight();
					currentlyHighlightedTile = null;
				}
			}

		}
		else
		{

			if (currentlyHighlightedTile != null)
			{
				currentlyHighlightedTile.Unhighlight();
			}
		}




	}
}
