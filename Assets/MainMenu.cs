using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void PlayLevOne () {
        SceneManager.LoadScene(1);
    }

    public void PlayLevTwo () {
        SceneManager.LoadScene(2);
    }


    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }
}
