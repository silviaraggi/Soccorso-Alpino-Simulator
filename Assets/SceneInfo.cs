using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    static int SceneNumber = 3;

    private void Update()
    {
        ToggleFullScreen();
    }

    public void SetScene(int scena)
    {
        SceneNumber = scena;
    }

    public int GetScene()
    {
        return SceneNumber;
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
