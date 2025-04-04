using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;

    void Start()
    {
        infoPanel.SetActive(false);
    }
    public void HideInfoPanel()
    {
        infoPanel.SetActive(false);
    }

    public void ShowInfoPanel()
    {
        infoPanel.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
