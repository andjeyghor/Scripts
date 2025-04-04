using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public static int count = 0;
    public static int bonus = 0;
    public static int allCount = 0;
    [SerializeField] TMP_Text countText, timerText, statisticText, dayText;
    [SerializeField] Button mainButton;
    [SerializeField] GameObject particleSystemOnScene;
    [SerializeField] Button taskButton, upgradeButton;
    [SerializeField] Image taskInfoImage;
    static public int day = 1;
    bool clickState = false;
    void Start()
    {
        CheckCash();
        CheckDay();
        UpdateUI();
        UpdateStatistic();
        taskInfoImage.enabled = false;
        taskButton.interactable = false;
    }
    void Update()
    {
        // Перевірка на початок гри(на можливість клікати)
        if (Timer.mainTimer > 0
        && timerText.GetComponent<Timer>().threeSecondsTimer <= 0)
        {
            clickState = true;
            particleSystemOnScene.SetActive(true);
        }
        else
        {
            clickState = false;
            particleSystemOnScene.SetActive(false);
        }
    }
    // Метод, який викликається при кліку на гроші
    public void Clicked()
    {
        if (clickState)
        {
            count += 1 + bonus;
            allCount += 1;
            UpdateUI();
        }
    }
    // Оновлює частини інтерфейсу в головній сцені
    void UpdateUI()
    {
        countText.text = count.ToString();
        dayText.text = "День " + day.ToString();
    }
    // Оновлює статистику на головній сцені
    void UpdateStatistic()
    {
        statisticText.text = $"{bonus} дод. кліків \\ {Timer.mainTimer} секунд";
    }
    // Перевіряє, щоб дод. кліки не були менше нуля(для полегшення гри)
    public static void CheckBonus()
    {
        if (bonus < 0)
        {
            bonus = 0;
        }
    }
    // Перевіряє закінчення гри
    void CheckDay()
    {
        if (day >= 15)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
    // Перевіряє баланс на досягнення цілі
    void CheckCash()
    {
        if(count >= 15000)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
    // Викидає завдання(ліва верхня іконка на головній сцені) з шансом 50 на 50
    public void DiceTask()
    {
        int rand = Random.Range(0, 101);
        if (rand >= 50)
        {
            taskInfoImage.enabled = true;
            taskButton.interactable = true;
            upgradeButton.enabled = false;
        }
    }
}
