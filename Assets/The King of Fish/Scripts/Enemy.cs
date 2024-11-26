using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 sizeRange;
    [HideInInspector] public float enemySize;
    [SerializeField] private float speed = 2.0f;
    void Start()
    {
        //spawn fish at random size
        enemySize = Random.Range(sizeRange.x, sizeRange.y);
        transform.localScale = Vector3.one * enemySize;
    }

    // Update is called once per frame
    void Update()
    {
        //move enemy
        transform.position += transform.right * speed * Time.deltaTime;
    }   

}
