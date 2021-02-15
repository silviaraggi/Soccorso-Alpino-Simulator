using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 30;
    public bool takingAway = false;

    bool intro;
    bool finale;
    GameObject timer;


    void Start()
    {

        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;
        timer = GameObject.Find("Text_Timer");
        timer.SetActive(false);

    }

    void Update()
    {
        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;
        
        if (!intro && !finale)
        {
            timer.SetActive(true);
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;

            if(takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            } 
        }
        
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }

        takingAway = false;
        
    }


}*/

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    private float tempoRimanente = 600;
    public bool takingAway = false;

    bool intro;
    bool finale;
    GameObject timer;

    Color red;


    void Start()
    {

        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;
        timer = GameObject.Find("Text_Timer");
        timer.SetActive(false);
        red = Color.red;
    }

    void Update()
    {
        intro = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().intro;
        finale = GameObject.Find("GestoreScena").GetComponent<GestoreScenaValanga>().finale;

        if (!intro && !finale)
        {
            timer.SetActive(true);
            takingAway = true;
            if (takingAway == true && tempoRimanente > 0)
            {

                timer.GetComponent<Text>().color = Color.Lerp(timer.GetComponent<Text>().color, red, Time.deltaTime / tempoRimanente);
                tempoRimanente -= Time.deltaTime;
                DisplayTime(tempoRimanente);
                
            }
            else
            {
                Debug.Log("Time is over");
                tempoRimanente = 0;
                takingAway = false;
            }
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textDisplay.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    


}

