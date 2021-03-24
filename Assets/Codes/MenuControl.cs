using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteAll();   
    }
    public void startGame()
    {
        int saveLevel = PlayerPrefs.GetInt("save");

        if (saveLevel == 0)
        {
            SceneManager.LoadScene(saveLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(saveLevel);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
