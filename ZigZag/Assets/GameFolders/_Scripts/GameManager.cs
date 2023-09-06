using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int CubeCount { get; set; }
    public int Score { get; set; }
    public bool IsGameOver { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Score = 0;
    }
}


