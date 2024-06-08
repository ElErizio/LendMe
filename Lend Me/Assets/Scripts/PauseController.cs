using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void PauseGame()
    {
       
        Time.timeScale = 0;
       
    }
}
