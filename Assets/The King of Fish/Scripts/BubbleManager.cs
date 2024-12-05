using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    //reference to good and bad bubble prefabs
    public GameObject[] goodBubblePrefab;
    public GameObject[] badBubblePrefab;
    //variables for bubble spawn
    public float spawnRate = 5f;
    public float spawnTime = 10f;
    private GameObject bubbleSpawn;
    private GameObject[] bubbleTypePrefab;
    private GameObject bubbleType;

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
        //spawn good bubble or bad bubble
        bubbleTypePrefab = (Random.Range(0, 2) == 0 ? goodBubblePrefab : badBubblePrefab);
        //spawn bubbles from bubble prefab
        bubbleType = bubbleTypePrefab[Random.Range(0, bubbleTypePrefab.Length)];
        //spawn bubbles at random position        
        Vector2 ramdomPosition = new Vector2(Random.Range(-10.0f, 10.0f), -6.0f);
        bubbleSpawn = Instantiate(bubbleType, ramdomPosition, Quaternion.identity);
        
    }
}
