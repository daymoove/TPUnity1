using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float maxspeed = 15f;
    private float minspeed = 5f;
    private float speed = 5f;
    public float accelerationTime = 60;
    private float time;
    public GameObject plateforme;

    public float spawnTime = 1f;

    void Start()
    {
        InvokeRepeating("Spawnplateforme", spawnTime, spawnTime);
    }

    
    void Update()
    {
        speed = Mathf.SmoothStep(minspeed, maxspeed, time / accelerationTime);
        time += Time.deltaTime;
    }

    void Spawnplateforme()
    {
        float num = Random.Range(-3, 2);
        plateforme.transform.position = new Vector2(transform.position.x, num);
        var newplateforme = GameObject.Instantiate(plateforme);
        newplateforme.GetComponent<Plateform>().speed = speed;
    }
}
