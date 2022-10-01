using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRock : MonoBehaviour
{
    public float speed = 1;
    public float RotAngleZ = 45;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.sqrMagnitude;
        float rZ = Mathf.SmoothStep(-15, RotAngleZ, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
