using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTarget : MonoBehaviour
{
	Highlightable currentHighlightable;

	void Update()
	{


		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			Highlightable highlightable = hit.collider.gameObject.GetComponent<Highlightable>();

			if (highlightable != null)
			{

				if (currentHighlightable != highlightable)
				{
					if (currentHighlightable != null)
					{
						currentHighlightable.Unhighlight();
					}

					currentHighlightable = highlightable;
					Debug.Log("Kupka");
					highlightable.Highlight();
				}

			}
			else
			{
				currentHighlightable.Unhighlight();
				currentHighlightable = null;
			}

		}
		else
		{
			currentHighlightable.Unhighlight();
		}




	}
}
