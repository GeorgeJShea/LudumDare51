using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using QFSW.MOP2;

public class RandomEffectManager : MonoBehaviour
{
    float timer;
    public TMPro.TextMeshProUGUI counter;
    private List<Action> actions;
    static public float globalGameSpeed = 1f;

    private void Start()
    {
        actions = new List<Action>();

        actions.Add(flipCamera);
        actions.Add(zoom);
        actions.Add(speedUp);
    }


    void Update()
    {
        timer += Time.deltaTime;
        

        if (timer >= 10)
        {
            actions[UnityEngine.Random.Range(0, actions.Count)]();
            
            timer = 0;
        }

        counter.text = Math.Floor(timer).ToString();
    }

    void flipCamera()
    {
        Debug.Log("Camera Flipped");
    }

    void zoom()
    {

        StartCoroutine("CameraZoom");
    }

    IEnumerator CameraZoom()
    {
        Debug.Log("Zoom");
        Camera.current.orthographicSize /= 2;

        yield return new WaitForSeconds(10);
        Camera.current.orthographicSize *= 2;
        Debug.Log("Zoom reverted");
    }

    void speedUp() {
        
        StartCoroutine("SpeedDouble");
        
    }

    IEnumerator SpeedDouble()
    {
        Debug.Log("Speed x2");
        globalGameSpeed *= 2;

        yield return new WaitForSeconds(10);
        globalGameSpeed /= 2;
        Debug.Log("Speed x2 reverted");
    }
}
