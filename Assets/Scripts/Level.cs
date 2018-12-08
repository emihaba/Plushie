using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{

	public GameObject endLevelScreen;

	public string nextLevelName;

	public void EndLevel()
	{
		endLevelScreen.gameObject.SetActive(true);
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
	}
}
