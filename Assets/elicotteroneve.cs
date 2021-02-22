using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elicotteroneve : MonoBehaviour
{
    public void EnableElicottero()
    {
        foreach(Renderer daAttivare in this.GetComponentsInChildren<Renderer>())
        {
            daAttivare.enabled = true;
        }
        this.gameObject.GetComponent<Animator>().enabled = true;
        this.gameObject.GetComponent<AudioSource>().enabled = true;
    }

    public void LoadMenu()
    {
        GameObject.Find("SceneInfo").GetComponent<SceneInfo>().Reload();
        GameObject.Find("TransizioneCanvas").GetComponent<Transition_animation>().entry_transition();
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Menu");
        Debug.Log("Loading menu...");
    }

}
