using QFSW.MOP2;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{

    public bool lost = false;
    public GameObject losescreen;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    static float timer;
    public Player player;
    public float globalGameSpeed = 1f;
    public static Level_Manager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void Update()
    {

        if (lost)
        {
                lose();
        }
        else {
            losescreen.SetActive(false);
            timer += Time.deltaTime;
        }

    }

    public void lose() {

        time.text = "Time Surived: \n " + Mathf.Floor(timer);
        score.text = "Score: \n " + player.score;
        losescreen.SetActive(true);    
        
    
    }

    public static void retry() {

        MasterObjectPooler.Instance.ReleaseAllInAllPools();
        SceneManager.LoadScene("SampleScene");

    }

    public static void returnToMainMenu() {

        MasterObjectPooler.Instance.ReleaseAllInAllPools();
        SceneManager.LoadScene("MainMenu");
    }

}
