using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    static int SceneNumber = 1;
    static bool punti=false;
    static int punteggio=50;
    public GameObject monete;
    

    private void Start()
    {
        
        
    }
    private void Update()
    {

        if (punti)
        {
            if(GameObject.Find("Monete"))
            monete.SetActive(true);
            if (punteggio == 0)
            {
                FindObjectOfType<MissionFailed>().Fine_monete();
            }
            ToggleFullScreen();
        }
        
        
    }

    public void SetScene(int scena)
    {
        SceneNumber = scena;
    }

    public int GetScene()
    {
        return SceneNumber;
    }
    public void SetPunti(bool puntibool)
    {
        punti=puntibool;
    }

    public bool GetPunti()
    {
        return punti;
    }
    public void SetPunteggio(int newpunteggio)
    {
        punteggio = newpunteggio;
    }

    public int GetPunteggio()
    {
        return punteggio;
    }
    private void ToggleFullScreen()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Screen.fullScreenMode != FullScreenMode.ExclusiveFullScreen)
            {
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Debug.Log("Full Screen!");
            }
            else
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Debug.Log("Windowed!");
            }
        }
    }
}
