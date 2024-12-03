using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    //add a play game method
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
