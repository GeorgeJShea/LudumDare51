using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSquish : MonoBehaviour
{

    public float speed = 2;
    public float pulse = 1;
    public Vector3 defaultSize;
    // Start is called before the first frame update
    void Start()
    {
        defaultSize = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 vec = new Vector3(Mathf.Sin(pulse * Time.time * speed) + offset, pulse * Mathf.Sin(Time.time * speed) + offset, pulse * Mathf.Sin(Time.time * speed) + offset);
        Vector3 vec = new Vector3(defaultSize.x, pulse * Mathf.Sin(Time.time * speed) + defaultSize.y, defaultSize.z);
        transform.localScale = vec;
    }
}
