using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject exitPanel;
    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetSettings()
    { 
        settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackFromSettingsButton()
    { 
        settingsPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ExitButton()
    { 
        gameObject.SetActive(false);
        exitPanel.SetActive(true);
    }

    public void BackFromExitButton()
    {
        exitPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public void YesExitButton()
    {
        Application.Quit();
    }
}
