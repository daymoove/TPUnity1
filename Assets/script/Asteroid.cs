using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float speed = 5f;
    public Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector2(transform.position.x, -5);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject);

        }
    }
}
