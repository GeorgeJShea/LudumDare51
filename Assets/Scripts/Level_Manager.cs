using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{

    static public bool lost = false;
    public GameObject losescreen;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    static float timer;

    void Update()
    {

        if (lost)
        {
            lose();
        }
        else {
            timer += Time.deltaTime;
        }

    }

    public void lose() {

        time.text = "Time Surived: \n " + Mathf.Floor(timer);
        score.text = "Score: \n " + Player.score;
        losescreen.SetActive(true);    
        
    
    }

}
