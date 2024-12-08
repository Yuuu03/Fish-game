using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    //reference to bubble prefabs
    public GameObject[] bubblePrefabs;
    //variables for bubble spawn
    public float spawnRate = 5f;
    public float spawnTime = 10f;
    private GameObject bubbleSpawn;
    private GameObject bubble;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(spawnTime);
        while (true)
        {
            Debug.Log("Bubble is spawned!");
            SpawnBubble();
            yield return new WaitForSeconds(spawnRate);
        }
        
    }

    private void SpawnBubble()
    {
        //spawn bubbles from bubble prefab
        bubble = bubblePrefabs[Random.Range(0, bubblePrefabs.Length)];
        //spawn bubbles at random position        
        Vector2 ramdomPosition = new Vector2(Random.Range(-10.0f, 10.0f), -6.0f);
        bubbleSpawn = Instantiate(bubble, ramdomPosition, Quaternion.identity);
        
    }
}
