using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smack : MonoBehaviour
{

    public float speed = 1;
    //public float[] speeds;
    public float RotAngleZ = 45;

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float rZ = Mathf.SmoothStep(-15, RotAngleZ, Mathf.PingPong(Time.time * speed, 1));
            transform.rotation = Quaternion.Euler(0, 0, rZ);
        }
    }
}
