using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    [SerializeField] TMP_Text allClick, clickCount, expendCount, daysCount;
    [SerializeField] GameObject mainPanel;
    void Start()
    {
        mainPanel.SetActive(false);
        allClick.text = $"Всього зроблено кліків: {ClickCounter.allCount}";
        clickCount.text = $"Отримано коштів: {ClickCounter.count}";
        expendCount.text = $"Витрачено коштів: {Upgrage.moneyExpend}";
        daysCount.text = $"Днів пройдено: {ClickCounter.day}";

    }
    public void CloseMainPanel()
    {
        mainPanel.SetActive(false);
    }
    public void OpenMainPanel()
    {
        mainPanel.SetActive(true);
    }
}
