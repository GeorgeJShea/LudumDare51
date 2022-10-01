using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public float offset = 0;
    // Start is called before the first frame update

    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z - 2*offset);

        }else{
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
        }
        
    }
}
