using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    public static int mainTimer = 15;
    public int threeSecondsTimer = 3;
    [SerializeField] TMP_Text dayText;
    [SerializeField] GameObject gameManager;
    void Start()
    {
        StartCoroutine(StartTimer());
    }
    IEnumerator StartTimer()
    {
        timerText.color = new Color(0, 255, 90);
        while (threeSecondsTimer > 0)
        {
            timerText.text = "00:0" + threeSecondsTimer.ToString();
            threeSecondsTimer--;
            yield return new WaitForSeconds(1f);
        }

        dayText.enabled = false;
        timerText.color = new Color(0, 0, 0);
        while (mainTimer > 0)
        {
            if (mainTimer > 9)
            {
                timerText.text = "00:" + mainTimer.ToString();
            }
            else
            {
                if (mainTimer <= 5)
                {
                    timerText.color = new Color(255, 0, 0);
                }
                timerText.text = "00:0" + mainTimer.ToString();
            }
            mainTimer--;
            yield return new WaitForSeconds(1f);
        }
        
        timerText.text = "Час вийшов!";
        timerText.GetComponent<Animator>().Play("TimerAnimationStop");
        gameManager.GetComponent<ClickCounter>().DiceTask();
    }
}
