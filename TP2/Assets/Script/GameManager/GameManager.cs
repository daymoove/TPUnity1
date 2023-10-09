using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Pause;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Pause.SetActive(true);
        }
    }
}
