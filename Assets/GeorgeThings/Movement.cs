using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float speedCap;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
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
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
        {
            rb.velocity = new Vector2(moveDir.x * moveSpeed * Time.deltaTime, moveDir.y * moveSpeed * Time.deltaTime);
        }
    }
