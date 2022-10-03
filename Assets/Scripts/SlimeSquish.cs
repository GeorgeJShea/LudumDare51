using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSquish : MonoBehaviour
{

    public float speed = 2;
    public float offset = 2;
    public float pulse = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vec = new Vector3(Mathf.Sin(pulse * Time.time * speed) + offset, pulse * Mathf.Sin(Time.time * speed) + offset, pulse * Mathf.Sin(Time.time * speed) + offset);
        Vector3 vec = new Vector3(2, pulse * Mathf.Sin(Time.time * speed) + offset, 2);
        transform.localScale = vec;
    }
}
