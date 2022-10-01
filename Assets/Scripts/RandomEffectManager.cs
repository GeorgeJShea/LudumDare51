using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomEffectManager : MonoBehaviour
{
    float timer;
    public TMPro.TextMeshProUGUI counter;
    private List<Action> actions;


    private void Start()
    {
        actions = new List<Action>();

        actions.Add(flipCamera);
        actions.Add(zoom);

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
        Debug.Log("Zoom");
    }
}
