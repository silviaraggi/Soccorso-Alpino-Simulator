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
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(1);
        SceneManager.LoadScene("Baita");
    }

    public void PlayDog()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().SetScene(2);
        SceneManager.LoadScene("Baita");
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
        Cursor.lockState = CursorLockMode.None;
    }
}
