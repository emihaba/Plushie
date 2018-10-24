using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;


public class PickupCollector : MonoBehaviour
{

	//TextMeshPro

	void Start()
	{

	}

	void Update()
	{



	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("kupeczka");
		if (other.gameObject.CompareTag("Star Pickup"))
		{
			Destroy(other.gameObject);
		}

	}
}
