using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private GameObject[] obstacles;
    private GameObject[] objtopush;
    public GameManager gamemanager;
    private bool readytomove;
    
    private void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("obstacles");
        objtopush = GameObject.FindGameObjectsWithTag("objtopush");
        gamemanager = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        Vector2 moveinput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveinput.Normalize();

        if (moveinput.sqrMagnitude >0.5)
        {
            if(readytomove)
            {
                readytomove = false;
                Move(moveinput);
            }
        } else
        {
            readytomove = true;
        }
    }

    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        } else
        {
            direction.y = 0;
        }
        direction.Normalize();

        if (Blocked(transform.position,direction))
        {
            return false;
        } else
        {
            gamemanager.Save(gameObject);
            transform.Translate(direction*Time.timeScale);
            
            return true;
        }
    }

    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;

        foreach (var obj in obstacles)
        {
            if(obj.transform.position.x == newpos.x && obj .transform.position.y ==newpos.y)
            {
                return true;
            }
        }

        foreach (var objpush in objtopush)
        {
            if (objpush.transform.position.x == newpos.x && objpush.transform.position.y == newpos.y)
            {
                gamemanager.Save(gameObject, objpush);
                Push objp = objpush.GetComponent<Push>();
                if (objp && objp.Move(direction)) 
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }
        return false;
    }
    

}
