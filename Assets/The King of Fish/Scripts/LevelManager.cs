using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //Assign level variable
    [HideInInspector]public string level;
    //add a LoadEasyLevel method
    public void LoadEasyLevel()
    {
        level = "Easy";
        SceneManager.LoadSceneAsync(1);
    }

    //add a LoadDifficultLevel method
    public void LoadDifficultLevel()
    {
        level = "Difficult";
        SceneManager.LoadSceneAsync(1);
    }

    //add a open menu method
    public void LoadMenuScene()
    {
        Debug.Log("Menu screen is loaded!");
        SceneManager.LoadSceneAsync(0);
    }

    //add a play game method to load test level scene
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
    
    //add a pause game method
    public void PauseGame()
    {
        Debug.Log("The game is paused!");
        //load pause scene
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        //freeze time
        Time.timeScale = 0;
    }

    //add a resume game method
    public void ResumeGame()
    {
        Debug.Log("Game continues!");
        //Unload the pasue scene
        SceneManager.UnloadSceneAsync(3);
        //set time to normal
        Time.timeScale = 1;
    }
    
}
