using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionFailed : MonoBehaviour
{
    public GameObject missionFailedUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//prova
    {
        if (Input.GetKeyDown(KeyCode.G))
    {
        Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
        Debug.Log("Missione Complete");
        missionFailedUI.SetActive(true);

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



    

    