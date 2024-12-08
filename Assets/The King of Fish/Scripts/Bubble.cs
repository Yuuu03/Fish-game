using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public string bubbleType;
    [SerializeField] private float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        //move bubble
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
