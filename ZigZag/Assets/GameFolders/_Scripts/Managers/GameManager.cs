using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int CubeCount { get; set; }
    public int Score { get; set; }
    public int GamesPlayed;
    public bool IsGameOver { get; set; }
    public bool IsGameStarted { get; set; }
    public int HighScore { get; private set; }

    private string highScore = "HighScore";
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        IsGameStarted = false;
        Score = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            StartGame();
        GamesPlayed = PlayerPrefs.GetInt("Games Played");   
        SetHighScore();
    }

    public void RestartGame()
    {
        IsGameOver = false;
        Score = 0;
        GamesPlayed++;
        PlayerPrefs.SetInt("Games Played",GamesPlayed);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        if (!IsGameStarted && !IsGameOver)
        {
            IsGameStarted = true;
            SoundManager.Instance.PlayOneShot(4);
        }
    }
    private void SetHighScore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(highScore,HighScore);
            PlayerPrefs.Save();
        }
        HighScore = PlayerPrefs.GetInt(highScore);
    }

    public void GameOver()
    {
        IsGameOver = true;
        IsGameStarted = false;
        SoundManager.Instance.PlayOneShot(2);
    }
}


