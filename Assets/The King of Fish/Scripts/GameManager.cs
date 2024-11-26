using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float randomx;
    public float spawnRate = 2.0f;
    
    
    //reference to enemy prefab
    public GameObject[] EnemyPrefab;
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
        
    }
    public void SpawnFish()
    {
        //spawn fish from enemy prefab
        GameObject fish = EnemyPrefab[Random.Range(0, EnemyPrefab.Length)];

        //spawn fish at random position
        randomx = (Random.Range(0, 2) == 0 ? -11.0f : 11.0f);
        Vector2 ramdomPosition = new Vector2(randomx, Random.Range(6.0f, -4.0f));
        GameObject fishSpawn = Instantiate(fish, ramdomPosition, Quaternion.identity);
        //change fish facing direction if it spawns at the right
        if (randomx == 11.0f) fishSpawn.transform.Rotate(0, 180, 0);
    }
}
