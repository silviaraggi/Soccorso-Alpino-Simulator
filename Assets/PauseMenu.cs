using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Sono in pausa");
            Cursor.lockState = CursorLockMode.None;
            if(GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
            GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().m_MouseLook.SetCursorLock(false);
            if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
                GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().m_MouseLook.SetCursorLock(false);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Debug.Log("Resume");
        Cursor.lockState = CursorLockMode.Locked;
        if(GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>())
        GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUNDElicottero>().m_MouseLook.SetCursorLock(true);
        if (GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>())
            GameObject.Find("Player").GetComponent<FirstPersonCharacterControllerSOUND>().m_MouseLook.SetCursorLock(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        Debug.Log("Pausa");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

}
