using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_move : MonoBehaviour
{
    [SerializeField]
    GameObject WinScreen;
    [SerializeField]
    GameObject Losescreen;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedrotation;

    private float move;
    private float rotation;


    void Update(){

        move = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        rotation = Input.GetAxisRaw("Horizontal") * -speedrotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            speed = 9f;
        } else
        {
            speed = 5f;
        }
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Ennemy") )
        {
            Destroy(gameObject);
            Losescreen.SetActive(true);
            Time.timeScale = 0f;

        } else if (collision.gameObject.tag == "Finish")
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
