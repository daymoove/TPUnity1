using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float speed = 1f;
    public Vector3 targetPosition;

    private void Start()
    {
        targetPosition = new Vector2(transform.position.x, -5);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position.y == -5)
        {
            Destroy(gameObject);
        }
    }
}
