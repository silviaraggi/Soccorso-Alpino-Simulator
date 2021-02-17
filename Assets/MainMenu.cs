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
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(1);
        SceneManager.LoadSceneAsync("Baita");
        
    }

    public void PlayDog()
    {
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(2);
        SceneManager.LoadSceneAsync("Baita");

    }

    public void PlaySnow()
    {
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
    }

}
