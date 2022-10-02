using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject startPosit;
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = .01f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current = Random.Range(0, waypoints.Length);
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = startPosit.transform.position;
        }
    }
}
