using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{    
    //add a open menu method
    public void LoadMenuScene()
    {
        Debug.Log("Menu screen is loaded!");
        SceneManager.LoadSceneAsync(0);
    }

    //add a play game method
    public void PlayGame()
    {
        Debug.Log("Game starts!");
        SceneManager.LoadSceneAsync(1);
    }
    //add a exit game method
    public void QuitGame()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}
