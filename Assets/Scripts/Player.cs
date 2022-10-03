using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Entity
{
    private Vector2 moveDir;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private Rigidbody2D rb;
    private Animator anime;
    [SerializeField] private Collider2D swordHitBox;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        //anime = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Level_Manager.instance.lost) {
            return;
        }


        scoreText.text = score.ToString();


        Inputs();
        

        if(timeTillNextHit>0)timeTillNextHit-=Time.deltaTime;

        if(currentHealth<=0){
            Level_Manager.instance.lost = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(timeTillNextHit<=0)
        {
            if(col.gameObject.tag == "Enemy"){
                col.gameObject.GetComponent<Entity>().currentHealth-=5;
                timeTillNextHit = timeBetweenHits;
            }
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * speed * Time.deltaTime, moveDir.y * speed * Time.deltaTime);
    }

    private void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        swordHitBox.enabled = Input.GetKey(KeyCode.Mouse0);

        //Debug.Log(moveX);
        if (moveX != 0)
        {
            transform.localScale = new Vector3( moveX, transform.localScale.y, transform.localScale.z);
        }
        moveDir = new Vector2(moveX, moveY).normalized;
    }
}
