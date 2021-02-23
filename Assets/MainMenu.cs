using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();

    }

    public void PlayElicopter()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(false);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(1);
        SceneManager.LoadSceneAsync("Baita");
        
    }

    public void PlayDog()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(false);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(2);
        SceneManager.LoadSceneAsync("Baita");

    }

    public void PlaySnow()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(false);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(3);
        SceneManager.LoadSceneAsync("montagna_neve_TUTTOSCRIPT");
   
    }


    public void PlayElicopterGame()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(true);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(1);
        SceneManager.LoadSceneAsync("Baita");

    }

    public void PlayDogGame()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(true);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(2);
        SceneManager.LoadSceneAsync("Baita");

    }

    public void PlaySnowGame()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetPunti(true);
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(3);
        SceneManager.LoadSceneAsync("montagna_neve_TUTTOSCRIPT");

    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
