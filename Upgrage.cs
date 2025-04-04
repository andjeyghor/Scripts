using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrage : MonoBehaviour
{
    [SerializeField] TMP_Text moneyBalanceText;
    [SerializeField] GameObject[] upgradeButtons;
    static List<int> pressedButtons = new List<int>();          // Сюди будуть записуватися індекси кнопок, які були нажаті
    int[] prices = {50, 500, 750, 600, 1200, 1600, 2100, 1500};
    public static int moneyExpend = 0;
    [SerializeField] TMP_Text[] pricesText;
    void Start()
    {
        WritePricesInPricesText();
        UpdateButtons();
        Timer.mainTimer = 15;
    }
    // Робить доступними тільки ті кнопки, які не були нажаті і на які вистачає коштів на покупку
    void UpdateButtons()
    {
        if(pressedButtons.Count != 0)
        {
            for(int i = 0; i < pressedButtons.Count; i++)
            {
                upgradeButtons[pressedButtons[i]].SetActive(false);
            }           
        }
        if(ClickCounter.count >= 0)
        {
            for(int i = 0; i < prices.Length; i++)
            {
                if(prices[i] > ClickCounter.count)
                {
                    upgradeButtons[i].SetActive(false);
                }               
            }
        }
    }

    void Update()
    {
        moneyBalanceText.text = "Баланс: " + ClickCounter.count.ToString();
    }

    public void OnClickUpgradeOne()
    {
        ClickCounter.bonus += 1;
        ClickCounter.count -= prices[0];
        moneyExpend += prices[0];
        pressedButtons.Add(0);
        UpdateButtons();
    }
    public void OnClickUpgradeTwo()
    {
        ClickCounter.bonus += 2;
        ClickCounter.count -= prices[1];
        moneyExpend += prices[1];
        pressedButtons.Add(1);
        UpdateButtons();
    }
    public void OnClickUpgradeThree()
    {
        ClickCounter.bonus += 3;
        ClickCounter.count -= prices[2];
        moneyExpend += prices[2];
        pressedButtons.Add(2);
        UpdateButtons();
    }
    public void OnClickUpgradeFour()
    {
        Timer.mainTimer += 5;
        ClickCounter.count -= prices[3];
        moneyExpend += prices[3];
        pressedButtons.Add(3);
        UpdateButtons();
    }
    public void OnClickUpgradeFive()
    {
        Timer.mainTimer += 10;
        ClickCounter.count -= prices[4];
        moneyExpend += prices[4];
        pressedButtons.Add(4);
        UpdateButtons();
    }
    public void OnClickUpgradeSix()
    {
        Timer.mainTimer += 15;
        ClickCounter.count -= prices[5];
        moneyExpend += prices[5];
        pressedButtons.Add(5);
        UpdateButtons();
    }
    public void OnClickUpgradeSeven()
    {
        Timer.mainTimer += 20;
        ClickCounter.count -= prices[6];
        moneyExpend += prices[6];
        pressedButtons.Add(6);
        UpdateButtons();
    }
    public void OnClickUpgradeEight()
    {
        ClickCounter.bonus += 10;
        ClickCounter.count -= prices[7];
        moneyExpend += prices[7];
        pressedButtons.Add(7);
        UpdateButtons();
    }
    // Пише відповідну ціну на апгрейді(додано, щоб не змінювати їх вручну в сцені)
    void WritePricesInPricesText()
    {
        for(int i = 0; i < prices.Length; i++)
        {
            pricesText[i].text = prices[i].ToString();
        }
    }
}
