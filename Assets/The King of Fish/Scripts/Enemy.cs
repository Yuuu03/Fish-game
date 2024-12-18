using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 sizeRange;
    public string level;
    [HideInInspector] public float enemySize;
    [SerializeField] private float speed = 2.0f;
    void Start()
    {
        level = PlayerPrefs.GetString("Level", "None");
        //spawn fish at random size
        sizeRange = GetSizeRange();
        enemySize = Random.Range(sizeRange.x, sizeRange.y);
        transform.localScale = Vector3.one * enemySize;
    }

    // Update is called once per frame
    void Update()
    {
        //move enemy
        transform.position += transform.right * speed * Time.deltaTime;
    }   
    //a method to get enemy spawn at different size range in different time period
    private Vector2 GetSizeRange()
    {
        if(level == "Easy")
        {
            //if time remaining is greater than 2 minutes
            if (GameManager.Instance.timeLeft > 240)
            {
                return new Vector2(0.5f, 1.5f);
            }
            else if (GameManager.Instance.timeLeft > 120)
            {
                return new Vector2(0.5f, 5.0f);
            }
            else
            {
                return new Vector2(0.5f, 7.0f);
            }
        }
        else if(level == "Difficult")
        {
            //if time remaining is greater than 2 minutes
            if (GameManager.Instance.timeLeft > 120)
            {
                return new Vector2(0.5f, 1.5f);
            }
            else if (GameManager.Instance.timeLeft > 60)
            {
                return new Vector2(0.5f, 5.0f);
            }
            else
            {
                return new Vector2(0.5f, 7.0f);
            }
        }
        else
        {
            return new Vector2(0.5f, 5.0f);
        }
             
    }
}
