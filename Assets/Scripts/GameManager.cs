using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[SerializeField] private GameObject startPanel;
	[SerializeField] private GameObject gamePanel;
	[SerializeField] private GameObject endPanel;
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private TMP_Text scoreEndText;
	[SerializeField] private TMP_Text bestScoreText;
	[SerializeField] private TMP_Text bestScoreText1;

	int highScore;

	private void Awake()
	{
		if(instance == null)
			instance = this;
	}

	private void Start()
	{
		SpawnManager.instance.enabled = false;
		highScore = PlayerPrefs.GetInt("HighScore");
		bestScoreText1.text = "Best Score " + highScore.ToString();
	}

	private void Update()
	{
		highScore = PlayerPrefs.GetInt("HighScore");
		SaveHighScore();

		scoreText.text = SpawnManager.instance.spawnedObject.ToString();
	}
	public void EndGame()
	{
		Time.timeScale = 0;
		scoreEndText.text = SpawnManager.instance.spawnedObject.ToString();
		bestScoreText.text = "Best Score " + highScore.ToString();
		gamePanel.SetActive(false);
		endPanel.SetActive(true);
	}

	public void PLayGame()
	{
		Time.timeScale = 1;
		SpawnManager.instance.enabled = true;
		startPanel.SetActive(false);
		gamePanel.SetActive(true);
	}

	public void ReloadGame()
	{
		SceneManager.LoadScene(0);
	}

	void SaveHighScore()
	{
		if (SpawnManager.instance.spawnedObject > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", SpawnManager.instance.spawnedObject);
		}
	}
}
