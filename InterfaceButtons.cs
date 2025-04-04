using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceButtons : MonoBehaviour
{
    
    public void OpenMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void OpenTasksScene()
    {
        SceneManager.LoadScene("TasksScene");
    }
    public void OpenUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeScene");
        ClickCounter.day++;
    }
    public void OpenMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
