using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    public GameObject asteroid;

    public float spawnTime = 1f;

    void Start()
    {
        
        InvokeRepeating("SpawnAsteroid", spawnTime, spawnTime);
    }


    void Update()
    {
        


    }

    void SpawnAsteroid()
    {
        float num = Random.Range(-10, 10);
        asteroid.transform.position = new Vector2(num, transform.position.y);
        var newasteroid = GameObject.Instantiate(asteroid);
    }
}
