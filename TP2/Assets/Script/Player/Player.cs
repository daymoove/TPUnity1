using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump;
    private float jumpcount = 0;
    private bool isGrounded;
    public GameObject End;
    private int score = 0;
    public TMP_Text actualscore;
    public TMP_Text finalScore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isGrounded || jumpcount < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
                jumpcount++;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpcount = 0;

        } else if (collision.gameObject.CompareTag("Void"))
        {
            Time.timeScale = 0f;
            End.SetActive(true);
            finalScore.text = "Your Score : " + score.ToString();
        } else if (collision.gameObject.CompareTag("Plateforme"))
        {
            isGrounded = true;
            score++;
            actualscore.text = "Score : " + score.ToString();
            jumpcount = 0;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        isGrounded = false;

    }
}
