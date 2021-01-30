using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestoreScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSceneByID(int ID)
    {
        SceneManager.LoadSceneAsync(ID);
    }
}
