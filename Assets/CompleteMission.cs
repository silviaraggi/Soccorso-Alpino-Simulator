using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMission : MonoBehaviour
{
    public GameObject missionCompleteUI;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
            Debug.Log("Missione Complete");
            missionCompleteUI.SetActive(true);
            
        }
    }
     public void Fine()
    {
        Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
        Debug.Log("Missione Complete");
        missionCompleteUI.SetActive(true);
    }
}

    

    