using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MissionFailed : MonoBehaviour
{
    public GameObject missionFailedUI;
    public bool tempoScaduto;
    // Start is called before the first frame update
    void Start()
    {
        tempoScaduto = false;
    }

    // Update is called once per frame
    void Update()//prova
    {
        if (tempoScaduto)
    {
        Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
        Debug.Log("Missione Complete");
        missionFailedUI.SetActive(true);
            this.gameObject.GetComponent<AudioSource>().enabled = true;

    }
    }
    public void Fine()
    {
        Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
        Debug.Log("Missione Complete");
        missionFailedUI.SetActive(true);
    }

    public void Ritenta()
    {
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        SceneManager.LoadSceneAsync("montagna_neve_TUTTOSCRIPT");
    }

}

// Start is called before the first frame update


// Update is called once per frame



    

    