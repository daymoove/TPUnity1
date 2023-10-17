using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] end;
    private GameObject[] objtopush;
    private List<bool> wintable = new List<bool>();
    private bool win = false;
    private int numboolverif;
    private GameObject pause;
    private GameObject youwin;

    public class Undo
    {
        public GameObject player;
        public GameObject Obj;
        public Vector3 playermove;
        public Vector3 ObjMove;
    }

    public List<Undo> LastActions = new List<Undo>();
    void Start()
    {
        pause = GameObject.Find("UI/PauseOBJ");
        youwin = GameObject.Find("UI/YouWin");
        pause.SetActive(false);
        youwin.SetActive(false);
        end = GameObject.FindGameObjectsWithTag("end");
        objtopush = GameObject.FindGameObjectsWithTag("objtopush");
        
        foreach (var e in end)
        {
            wintable.Add(false);
        }
    }


    void Update()
    {
        numboolverif = 0;
        foreach (var endobj in end)
        {
            foreach (var obj in objtopush)
            {
                if (endobj.transform.position == obj.transform.position)
                {
                    wintable[numboolverif] = true;
                    break;
                } else
                {
                    wintable[numboolverif] = false;
                }

            }
            numboolverif++;
        }

        for (int i = 0; i < wintable.Count; i++)
        {
            if (wintable[i] == true)
            {
                if (i == wintable.Count - 1)
                {
                    win = true;
                }
                continue;

            } else
            {
                break;
            }
        }
        if (win == true)
        {
            
            youwin.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if(LastActions.Count >0)
            {
                Load();
            }
            
            
        }

    }

    public void Save(GameObject Player, GameObject ObjPush = null)
    {
        
        Undo save = new Undo();
        save.player = Player;
        save.playermove = Player.transform.position;
        save.Obj = ObjPush;
        if (ObjPush != null)
        {
            save.ObjMove = ObjPush.transform.position;
        }
        
        LastActions.Add(save);
    }

    public void Load()
    {
        
        LastActions[LastActions.Count - 1].player.transform.position = LastActions[LastActions.Count - 1].playermove;
        
        if (LastActions[LastActions.Count - 1].Obj != null)
        {
            LastActions[LastActions.Count - 1].Obj.transform.position = LastActions[LastActions.Count - 1].ObjMove;
        }
        LastActions.Remove(LastActions[LastActions.Count - 1]);
    }
}
