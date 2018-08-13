using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
	public Color highlightColor;
	Color baseColor;
	Color targetColor;
	Renderer renderer;
	public float colorTransitionSpeed = 10;

	private void Awake()
	{
		renderer = GetComponentInChildren<Renderer>();
		baseColor = renderer.materials[1].color;
		targetColor = baseColor;
	}

	private void Update()
	{
		if (renderer.materials[1].color.Equals(targetColor) == false)
		{
			renderer.materials[1].color = Color.Lerp(renderer.materials[1].color, targetColor, colorTransitionSpeed * Time.deltaTime);
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
