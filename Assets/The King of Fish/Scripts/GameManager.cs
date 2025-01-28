using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;
using Image = UnityEngine.UI.Image;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    //a property that holds a refernce to an instance of the Game Manager class
    public static GameManager Instance {  get; private set; }
    public string level;
    public bool gameOver = false;
    public bool winStatus = true;
    public float timeLeft = 300f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goalText;
    Color col;
    [HideInInspector] public int score = 0;
    //variables for enemy spawn
    private float randomX;
    private float spawnRate;
    private GameObject fishSpawn;
    //variables for player health
    public int live = 3;
    public Image[] liveIcon;
    public Sprite fullLife;
    public Sprite emptyLife;
 
    //reference to enemy prefab
    public GameObject[] EnemyPrefab;

    //Awake method to set up the reference to the Instance
    private void Awake()
    {
        //if the instance is not null and the game object is not the instance
        if (Instance != null && Instance!= this)
        {
            //destroy the game object
            Destroy(this.gameObject);
        }
        else
        {
            //set the object's instance of the Game Manager class to be the instance
            Instance = this;
        }     
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Color color = goalText.color;
        col = color;

        level = PlayerPrefs.GetString("Level", "None");

        //if Level is equal to Easy
        if(level == "Easy")
        {
            //Set spawn rate and time left
            spawnRate = 1.5f;
            timeLeft = 300f;
            Debug.Log("The current level is Easy.");
        }
        else if(level == "Difficult")
        {
            //Set spawn rate the time left if level is difficult
            spawnRate = 2f;
            timeLeft = 180f;
            Debug.Log("The current level is Difficult.");
        }
        else
        {
            Debug.Log("The current level is unknown!");
        }

        //if enemy prefab is not null
        if (EnemyPrefab.Length > 0)
        {
            InvokeRepeating("SpawnFish", 1.0f, spawnRate);
        }
        else
        {
            Debug.Log("The enemy prefab is empty!");
        }       
    }

    // Update is called once per frame
    void Update()
    {
        //call UpdateScoreText method to update the score constantly
        UpdateScoreText();
        //call UpdateTimeText method to update the time constantly
        UpdateTimeText();

        //fade out goal text
        if(col.a > 0)
        {
            col.a -= Time.deltaTime/5.0f;
            goalText.color = col;
        }

        //stop spawning fish if game is over
        if (gameOver == true) CancelInvoke("SpawnFish");

        foreach (Image img in liveIcon)
        {
            img.sprite = emptyLife;
        }
        for (int i = 0; i < live; i++)
        {
            liveIcon[i].sprite = fullLife;
        }

    }
   
    //spawn enemy fish method
    private void SpawnFish()
    {
        //spawn fish from enemy prefab
        GameObject fish = EnemyPrefab[Random.Range(0, EnemyPrefab.Length)];

        //spawn fish at random position
        randomX = (Random.Range(0, 2) == 0 ? -11.0f : 11.0f);
        Vector2 ramdomPosition = new Vector2(randomX, Random.Range(6.0f, -4.0f));
        fishSpawn = Instantiate(fish, ramdomPosition, Quaternion.identity);
        //change fish facing direction if it spawns at the right
        if (randomX == 11.0f) fishSpawn.transform.Rotate(0, 180, 0);
    }

    //update player life method
    public void UpdatePlayerLife()
    {
        //subract player life by 1
        live -= 1;
        Debug.Log("Lose one life!");
        //if player life is less than or euqal to 0
        if (live <= 0)
        {
            winStatus = false;
            GameOver();
        }
    }

    //update player score method
    public void UpdateScore()
    {
        score += 100;
        Debug.Log($"Current score:{score}");        
    }
    //update score text method
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    //update time remaining method
    public void UpdateTime()
    {
        
        //if game is not over
        if (gameOver == false)
        {
            //reduce time if there is time left
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            //set time left to zero if there is no time left
            else
            {
                winStatus = false;
                timeLeft = 0;
            }            
        }        
        else
        {
            timeLeft = 0;
        }
    }

    //update time text method
    void UpdateTimeText()
    {
        UpdateTime();
        //calculate the minutes and seconds
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        //display time in the screen
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   

    //game over method
    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game is over!");
        //load game over scene
        SceneManager.LoadSceneAsync(2);      
        //save winStatus to playerprefs
        PlayerPrefs.SetInt("WinStatus", winStatus ? 1 : 0);
        //save score to playerprefs
        PlayerPrefs.SetInt("Score", score);
    }
}
