using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenScene(int sceneIndex)
    {
        Time.timeScale = 1;
        Statics.playerCanFire = true;
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenScene(string sceneName)
    {
        Time.timeScale = 1;
        Statics.playerCanFire = true;
        SceneManager.LoadScene(sceneName);
    }

    public void Resume(GameObject menu)
    {
        Time.timeScale = 1;
        Statics.playerCanFire = true;
        menu.SetActive(false);
    }

    public void OpenMenu(GameObject menu)
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Statics.playerCanFire = true;
        Application.Quit();
    }
}
