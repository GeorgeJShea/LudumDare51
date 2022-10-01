using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRock : MonoBehaviour
{
    public float speed = 1;
    public float check;
    //public float[] speeds;
    public float RotAngleZ = 45;


    [SerializeField] private Gradient gradient;
    [SerializeField] private float duration;
    public float t = 0f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*

        float value = Mathf.Lerp(0f, 1f, t);
        t += Time.deltaTime / duration;
        Color color = gradient.Evaluate(value);
        //Camera.main.backgroundColor = color;

        if(color.r <= 1)
        {
            speed = color.r;
        }
        if (t > 1)
        {
            t = 0;
        }
        */
        speed = rb.velocity.magnitude;
        if (rb.velocity.magnitude == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        { 
            float rZ = Mathf.SmoothStep(-15, RotAngleZ, Mathf.PingPong(Time.time * speed, 1));
            transform.rotation = Quaternion.Euler(0, 0, rZ);
        }


    }
}
