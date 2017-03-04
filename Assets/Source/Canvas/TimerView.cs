using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour {

    public Text timerText;

    public void UpdateTimer(float timeInSeconds)
    {
        string minutes = ((int) (timeInSeconds / 60)).ToString();
        string seconds = ((int)(timeInSeconds % 60)).ToString();

        if(seconds.Length < 2)
        {
            seconds = "0" + seconds;
        }

        timerText.text = minutes + ":" + seconds; 
    }
}
