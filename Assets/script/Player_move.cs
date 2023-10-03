using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_move : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedrotation;

    private float move;
    private float rotation;

    private float life = 3;
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
        if ((collision.gameObject.tag == "Ennemy") && life > 0)
        {
            transform.position = new Vector2(0, -5);
            life--;
        } else if ((collision.gameObject.tag == "Ennemy") && life <= 0)
        {
            Destroy(gameObject);
        }
            
    }


}
