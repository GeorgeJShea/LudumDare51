using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Entity
{
    private Vector2 moveDir;
    static public int score = 0;
    public TextMeshProUGUI scoreText;
    private Rigidbody2D rb;
    private Animator anime;
    public Transform weapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //anime = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        scoreText.text = score.ToString();

        Inputs();

        if(currentHealth<=0){
            Debug.Log("Player has died");
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed * Time.deltaTime, moveDir.y * speed * Time.deltaTime);
    }

    private void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Debug.Log(moveX);
        if (moveX != 0)
        {
            transform.localScale = new Vector3( moveX, transform.localScale.y, transform.localScale.z);
        }
        moveDir = new Vector2(moveX, moveY).normalized;
    }
}
