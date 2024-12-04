using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    //reference to good and bad bubble prefabs
    public GameObject[] goodBubblePrefab;
    public GameObject[] badBubblePrefab;
    //variables for bubble spawn
    private float randomX;
    public float spawnRate = 30f;
    private GameObject bubbleSpawn;
    private GameObject[] bubbleTypePrefab;
    private GameObject bubbleType;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.timeLeft > 240)
        {
            if (goodBubblePrefab.Length > 0 && badBubblePrefab.Length > 0)
            {
                InvokeRepeating("SpawnBubble", spawnRate, spawnRate);
            }
            else
            {
                Debug.Log("The bubble prefab is empty!");
            }
        }
    }

    private void SpawnBubble()
    { 
        //spawn good bubble or bad bubble
        bubbleTypePrefab = (Random.Range(0, 2) == 0 ? goodBubblePrefab : badBubblePrefab);
        //spawn bubbles from bubble prefab
        bubbleType = bubbleTypePrefab[Random.Range(0, bubbleTypePrefab.Length)];
        //spawn bubbles at random position
        randomX = (Random.Range(0, 2) == 0 ? -10.0f : 10.0f);
        Vector2 ramdomPosition = new Vector2(randomX, Random.Range(6.0f, -6.0f));
        bubbleSpawn = Instantiate(bubbleType, ramdomPosition, Quaternion.identity);

    }
}
