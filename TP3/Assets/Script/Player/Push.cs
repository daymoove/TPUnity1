using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private GameObject[] obstacles;
    private GameObject[] objtopush;
    private void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("obstacles");
        objtopush = GameObject.FindGameObjectsWithTag("objtopush");
    }

    public bool Move(Vector2 direction)
    {
        if (ObjToBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
    }


    public bool ObjToBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;

        foreach (var obj in obstacles)
        {
            if (obj.transform.position.x == newpos.x && obj.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objpush in objtopush)
        {
            if (objpush.transform.position.x == newpos.x && objpush.transform.position.y == newpos.y)
            {
                return true;
            }
        }
        return false;
    }
}
