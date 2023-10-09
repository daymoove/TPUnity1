using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour
{

    private Vector3 targetPosition;
    public float speed = 5f;
    void Start()
    {
        targetPosition = new Vector2(-13, transform.position.y);
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);



        if (transform.position.x <= -13)
        {
            Destroy(gameObject);
        }
    }
}
