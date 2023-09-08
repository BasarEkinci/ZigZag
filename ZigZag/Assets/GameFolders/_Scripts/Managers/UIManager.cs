using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreText2;
    [SerializeField] TMP_Text gamesPlayedText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text highScoreText2;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject socialsButtons;

    private void Start()
    {
        if(scoreText.gameObject.activeSelf)
            scoreText.gameObject.SetActive(false);
        startText.transform.DOScale(Vector3.one * 1.1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void Update()
    {
        SetText();
        GameOverActions();
        GameStartActions();
    }

    private void GameOverActions()
    {
        if (GameManager.Instance.IsGameOver)
        {
            scoreText.gameObject.SetActive(false);
            SoundManager.Instance.PlayOneShot(2);
            gameOverPanel.transform.DOScale(Vector3.one, 0.1f);
        }
    }

    private void GameStartActions()
    {
        if(GameManager.Instance.IsGameStarted)
        {
            socialsButtons.transform.DOMoveY(-1000f, 0.5f).SetEase(Ease.OutBack);
            startText.transform.DOScale(Vector3.zero, 0.2f);
            titleText.transform.DOMoveY(-100f, 0.02f);
            highScoreText.transform.DOScale(Vector3.zero, 0.1f);
            gamesPlayedText.transform.DOScale(Vector3.zero, 0.1f);
            scoreText.gameObject.SetActive(true);
        }
    }
    private void SetText()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
        scoreText2.text = "Score\n" + GameManager.Instance.Score;
        highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
        highScoreText2.text = "High Score\n" + GameManager.Instance.HighScore;
        gamesPlayedText.text = "Games Played: " + GameManager.Instance.GamesPlayed;
    }
    public void SocialsButton(string url)
    {
        Application.OpenURL(url);
    }
    public void RestartButton()
    {
        scoreText.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
