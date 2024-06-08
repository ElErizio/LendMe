using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ResumeController : MonoBehaviour
{
    public void ResumeGame()
    {
        
        Time.timeScale = 1.0f;
        
    }

    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
}
