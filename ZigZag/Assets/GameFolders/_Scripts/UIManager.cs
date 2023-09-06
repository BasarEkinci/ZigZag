using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = GameManager.Instance.Score.ToString();
    }
}
