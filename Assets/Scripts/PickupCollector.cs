using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PickupCollector : MonoBehaviour
{

	public TextMeshProUGUI text;
	int score = 0;

	void Start()
	{

	}

	void Update()
	{



	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Star Pickup"))
		{
			Destroy(other.gameObject);
			score++;
			text.text = score.ToString();
		}

	}
}
