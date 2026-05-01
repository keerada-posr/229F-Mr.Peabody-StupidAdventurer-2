using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
    public void StartGame()
    {
        
        SceneManager.LoadScene("Gamescene");
    }

    
    public void QuitGame()
    {
        
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void GoToMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }

    public void GoToCredits()
    {
        
        SceneManager.LoadScene("Endcredit 1");
    }
}