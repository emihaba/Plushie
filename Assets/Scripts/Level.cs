using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
	public static Level instance;

	public int levelSizeX;
	public int levelSizeY;

	public float tileSize = 1.0f;

	Vector2 centerIndex;

	public Tile[,] tiles;

	public GameObject TilesParent;

	public GameObject LevelObjectsParent;

	public GameObject endLevelScreen;

	public string nextLevelName;

	void Awake()
	{
		instance = this;

		tiles = new Tile[levelSizeX, levelSizeY];

		centerIndex = new Vector2((levelSizeX - 1) / 2, (levelSizeY - 1) / 2);

		FindTiles();
		FindLevelObjects();
	}

	void FindTiles()
	{
		Tile[] foundTiles = TilesParent.GetComponentsInChildren<Tile>();

		foreach (Tile tile in foundTiles)
		{
			Vector2 position = new Vector2(tile.transform.position.x, tile.transform.position.z);

			Vector2 indexOfPosition = IndexOfPosition(position);

			tiles[Mathf.RoundToInt(indexOfPosition.x), Mathf.RoundToInt(indexOfPosition.y)] = tile;
		}
	}

	Vector2 IndexOfPosition(Vector2 position)
	{
		return (position / tileSize) + centerIndex;
	}

	void FindLevelObjects()
	{
		LevelObject[] foundLevelObjects = LevelObjectsParent.GetComponentsInChildren<LevelObject>();

		foreach (LevelObject levelObject in foundLevelObjects)
		{
			Vector2 position = new Vector2(levelObject.transform.position.x, levelObject.transform.position.z);

			Vector2 indexOfPosition = IndexOfPosition(position);

			tiles[Mathf.RoundToInt(indexOfPosition.x), Mathf.RoundToInt(indexOfPosition.y)].levelObject = levelObject;
		}
	}

	public Tile GetTile(LevelObject levelObject)
	{
		foreach (var tile in tiles)
		{
			if (tile.levelObject == levelObject)
			{
				return tile;
			}
		}
		return null;
	}

	public void SetTileForObject(LevelObject levelObject, Tile targetTile)
	{
		GetTile(levelObject).levelObject = null;
		targetTile.levelObject = levelObject;
	}



	public void EndLevel()
	{
		endLevelScreen.gameObject.SetActive(true);
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
	}
}
