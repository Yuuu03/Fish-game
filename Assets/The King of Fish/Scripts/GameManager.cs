using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //a property that holds a refernce to an instance of the Game Manager class
    public static GameManager Instance {  get; private set; }
    public bool gameOver = false;
    public float timeLeft = 300.0f;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    //variables for enemy
    private float randomx;
    public float spawnRate = 2.0f;
    private GameObject fishSpawn;
    //variables for player
    public int live = 3;
    public int score = 0;
    

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
            //make the game manager persistent
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (EnemyPrefab.Length > 0)
        {
            InvokeRepeating("SpawnFish", spawnRate, spawnRate);
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
        
    }
   
    //spawn enemy fish method
    private void SpawnFish()
    {
        //spawn fish from enemy prefab
        GameObject fish = EnemyPrefab[Random.Range(0, EnemyPrefab.Length)];

        //spawn fish at random position
        randomx = (Random.Range(0, 2) == 0 ? -11.0f : 11.0f);
        Vector2 ramdomPosition = new Vector2(randomx, Random.Range(6.0f, -4.0f));
        fishSpawn = Instantiate(fish, ramdomPosition, Quaternion.identity);
        //change fish facing direction if it spawns at the right
        if (randomx == 11.0f) fishSpawn.transform.Rotate(0, 180, 0);
    }

    //update player life method
    public void UpdatePlayerLife()
    {
        //subract player life by 1
        live -= 1;
        Debug.Log("Lose one life!");
        //if player life is less than or euqal to 0
        if (live <= 0) GameOver();
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
        //reduce time if there is time left
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
        }
    }

    //update time text method
    void UpdateTimeText()
    {
        //calculate the minutes and seconds
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        //display time in the screen
        timeText.text = ("{0:00}:{1:00}", minutes, seconds).ToString();
    }

    //game over method
    private void GameOver()
    {
        gameOver = true;
        Debug.Log("Game is over!");
    }
}
