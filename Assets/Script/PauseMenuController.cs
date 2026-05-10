using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
 
public class PauseMenuController : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject guidebookUI;
 
    private bool isPaused = false;
 
    void Start()
    {
        pauseMenuUI.SetActive(false);
        guidebookUI.SetActive(false);
        Time.timeScale = 1f;
 
        // Keep cursor always visible for 2D mouse aiming
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
 
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (guidebookUI.activeSelf)
            {
                Resume();
                return;
            }
 
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        guidebookUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
 
        // Never lock cursor - mouse aim needs it free
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
 
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
 
    public void OpenGuidebook()
    {
        guidebookUI.SetActive(true);
    }
 
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
 
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit Game");
        Application.Quit();
    }
}