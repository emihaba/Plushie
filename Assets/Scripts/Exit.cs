using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Level level = gameObject.GetComponentInParent(typeof(Level)) as Level;

			if (level != null)
			{
				level.EndLevel();
			}
		}

	}
}
