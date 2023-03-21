using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Timer : MonoBehaviour
{
    public float GameSeconds;
    public float GameMinutes;

    string stringSeconds;
    string stringMinutes;

    public Text TextTimer;
    public float timeStart;
    bool isRunning= true;
             
    private void Start()
    {
        TextTimer.text = timeStart.ToString();
    }
    void Update()
    {
        if (isRunning == true)
        {
            timeStart -=Time.deltaTime;
            TextTimer.text=Mathf.Round(timeStart).ToString();
        }
        if (timeStart < 0)
        {
            //timeStart = 0;
            Losing();
        }
    }

    void Losing()
    {
        Game loser = GetComponent<Game>();
        loser.Lose();
    }
}
