using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    public void StopGame()
    { 
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    { 
        pausePanel.SetActive(false); 
        Time.timeScale = 1;
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
