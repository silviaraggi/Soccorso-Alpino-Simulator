using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestoreScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {

        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSceneByID(int ID)
    {

        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        SceneManager.LoadSceneAsync(ID);
    }
}
