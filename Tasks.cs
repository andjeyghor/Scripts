using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tasks : MonoBehaviour
{
    string[] tasks =
    {
        "У друга день народження. Ти приймаєш запрошення?", // 0
        "Друзі кличуть в кіно. Ти йдеш?",                   // 1
        "Брат просить дати грошей в борг. Твоє рішення.",   // 2
        "Ти бачиш вуличного музиканта. Підтримати його?",   // 3
        "Ти отримав премію!",                               // 4
        "Колеги запрошують на каву. Твоє рішення.",         // 5
        "Тебе загубив гаманець.",                           // 6
        "Взяти відпустку?",                                 // 7
        "Сходити в компютерний клуб?",                      // 8
    };

    [SerializeField] TMP_Text taskText;
    static List<int> completedTasks = new List<int>();      // Сюди записуються індекси завдань, які вже були відображені
    [SerializeField] GameObject moneyPicture, clockPicture ;
    [SerializeField] TMP_Text moneyPicText, clockPicText;
    [SerializeField] Button cancelButton;
    int randTask;
    void Start()
    {
        Timer.mainTimer = 15;
        randTask = DiceTask();
        CheckTaskElements();
        UpdateUI();
    }

    void UpdateUI()
    {
        taskText.text = tasks[randTask];
    }
    // Вибирає завдання навмання
    int DiceTask()
    {
        int randNum;
        while (true)
        {
            randNum = Random.Range(0, tasks.Length);
            if (completedTasks.Contains(randNum))
            {
                continue;
            }
            else
            {
                break;
            }
        }
        completedTasks.Add(randTask);
        return randNum;
    }
    // При випадінні четвертого або шостого завдання ховає деякі елементи UI
    void CheckTaskElements()
    {
        if(randTask == 4)
        {
            clockPicture.SetActive(false);
            clockPicText.text = " ";
            moneyPicText.text = "+1";
            cancelButton.enabled = false;

        }
        else if(randTask == 6)
        {
            clockPicture.SetActive(false);
            clockPicText.text = " ";
            moneyPicText.text = "-1";
            cancelButton.enabled = false;
        }
    }
    
    public void AcceptButtonPressed()
    {
        if(randTask == 4)
        {
            ClickCounter.bonus += 1;            
        }
        else
        {
            ClickCounter.bonus -= 1;
            ClickCounter.CheckBonus();
        }
        SceneManager.LoadScene("MainScene");
        ClickCounter.day++;
    }
    public void CancelButtonPressed()
    {
        if(clockPicText.text != " ")
        {
            Timer.mainTimer -= 5;
        }
        SceneManager.LoadScene("MainScene");
    }
}
