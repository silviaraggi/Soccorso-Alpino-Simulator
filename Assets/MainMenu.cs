using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void PlayElicopter()
    {
        SceneManager.LoadScene("montagna_elicottero");
    }

    public void PlayDog()
    {
        SceneManager.LoadScene("montagna_elicottero");
    }

    public void PlaySnow()
    {
        SceneManager.LoadScene("montagna_elicottero");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
