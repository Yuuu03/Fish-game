using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 sizeRange;
    public float spawnRate = 5.0f;
    [SerializeField] private float speed = 3.0f;
    [HideInInspector] public float enemySize;
    //reference to enemy prefab
    public GameObject[] EnemyPrefab;

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
        //move enemy
        transform.position += transform.right * speed * Time.deltaTime;
    }

    public void SpawnFish()
    {
        //spawn fish from enemy prefab
        GameObject fish = EnemyPrefab[Random.Range(0, EnemyPrefab.Length)];
        
        //spawn fish at random position
        Vector2 ramdomPosition = new Vector2(Random.Range(11.0f, -11.0f), Random.Range(6.0f, -6.0f));
        GameObject fishSpawn = Instantiate(fish, ramdomPosition, Quaternion.identity);

        //spawn fish at random size
        enemySize = Random.Range(sizeRange.x, sizeRange.y);
        fishSpawn.transform.localScale = Vector3.one * enemySize;
    }

}
