using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreText2;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text highScoreText2;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject titleText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject socialsButton;

    private void Start()
    {
        if(gameOverPanel.gameObject.activeSelf)
            gameOverPanel.SetActive(false);
        
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
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    private void GameStartActions()
    {
        if(GameManager.Instance.IsGameStarted)
        {
            socialsButton.transform.DOMoveX(-100f, 0.2f);
            startText.transform.DOMoveY(-100f, 0.02f);
            titleText.transform.DOMoveY(-100f, 0.02f);
            highScoreText.transform.DOScale(Vector3.zero, 0.01f);
            scoreText.gameObject.SetActive(true);
        }
    }
    private void SetText()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
        scoreText2.text = "Score\n" + GameManager.Instance.Score;
        highScoreText.text = "HighScore\n" + GameManager.Instance.HighScore;
        highScoreText2.text = "HighScore\n" + GameManager.Instance.HighScore;
    }
    public void SocialsButton()
    {
        Application.OpenURL("https://linktr.ee/basarekinci");
    }
    public void RestartButton()
    {
        scoreText.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
