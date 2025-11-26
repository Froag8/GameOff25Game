using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject gameOverUI;
    public TMP_Text finalScoreText;

    void Awake()
    {
        instance = this;
    }

    public void GameOver(int score)
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        finalScoreText.text = "Score: " + score;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
