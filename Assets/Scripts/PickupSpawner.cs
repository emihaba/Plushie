using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
	List<Tile> spawnPoints = new List<Tile>();
	public int pickupsToSpawn = 3;
	public PlayerMovement player;
	public GameObject starPickup;
	bool isSpawning = true;

	void Start()
	{

	}

	void LateUpdate()
	{


		if (isSpawning)
		{
			spawnPoints = player.walkableTiles;


			while (pickupsToSpawn > 0)
			{
				Tile spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

				Instantiate(starPickup, spawnPoint.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity, spawnPoint.transform);
				pickupsToSpawn--;


			}

			isSpawning = false;
		}


	}
}
