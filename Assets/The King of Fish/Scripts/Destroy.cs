using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //assign values to boundary
    private float leftBoundary = -11.0f;
    private float rightBoundary = 11.0f;
    private float topBoundary = 6.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < leftBoundary||transform.position.x>rightBoundary||transform.position.y>topBoundary)
            Destroy(gameObject);
    }
}
