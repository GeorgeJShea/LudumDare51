using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(h < 0 || v < 0 ){
            //this.GetComponent<SpriteRenderer>().flipX= true;
            //anime.SetBool("Moving",true);
        }else if(h> 0 || v > 0){
            //this.GetComponent<SpriteRenderer>().flipX= false;
            //anime.SetBool("Moving",true);
        }else{
            //anime.SetBool("Moving",false);
        }

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        

        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){
            transform.localScale = new Vector3(-1,1,1);

        }else{
            transform.localScale = new Vector3(1,1,1);
        }
    

        
    }

    
}
