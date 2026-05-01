using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    public GameObject gameOverPanel;   // A UI Panel in your Canvas
    public TextMeshProUGUI winnerText; // Text inside the panel

    void Awake()
    {
        Instance = this;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void PlayerDied(GameObject deadPlayer)
    {
        string winnerName = "";

        if (TurnManager.Instance.player1 != null &&
            deadPlayer == TurnManager.Instance.player1.gameObject)
        {
            winnerName = "Player 2 Wins!";
        }
        else if (TurnManager.Instance.player2 != null &&
                 deadPlayer == TurnManager.Instance.player2.gameObject)
        {
            winnerName = "Player 1 Wins!";
        }

        ShowGameOver(winnerName);
    }

    void ShowGameOver(string message)
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (winnerText != null)
            winnerText.text = message;

        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}