using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    public GameObject player1WinCanvas;  // Drag Canvas 2 here
    public GameObject player2WinCanvas;  // Drag Canvas 3 here

    void Awake()
    {
        Instance = this;
        player1WinCanvas.SetActive(false); // Both hidden at start
        player2WinCanvas.SetActive(false);
    }

    public void PlayerDied(GameObject deadPlayer)
    {
        if (TurnManager.Instance.player1 != null &&
            deadPlayer == TurnManager.Instance.player1.gameObject)
        {
            player2WinCanvas.SetActive(true); // P1 died = P2 wins
        }
        else if (TurnManager.Instance.player2 != null &&
                 deadPlayer == TurnManager.Instance.player2.gameObject)
        {
            player1WinCanvas.SetActive(true); // P2 died = P1 wins
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}