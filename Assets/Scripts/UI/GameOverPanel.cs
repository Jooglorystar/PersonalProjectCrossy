using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI gameEndTitle;
    public TextMeshProUGUI gameEndScore;

    private void OnEnable()
    {
        gameEndTitle.text = SetGameEndTitle();
        gameEndScore.text = SetGameEndScore();
    }

    private string SetGameEndTitle()
    {
        string titleString;

        titleString = "Game End";

        return titleString;
    }

    private string SetGameEndScore()
    {
        string scoreString;

        scoreString = $"Score\n{GameManager.Instance.collectedCoin+GameManager.Instance.timeScore}";

        return scoreString;
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
