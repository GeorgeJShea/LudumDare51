using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using QFSW.MOP2;
using TMPro;

public class RandomEffectManager : MonoBehaviour
{
    float timer;
    public TMPro.TextMeshProUGUI counter;
    private List<Action> actions;
    public Camera LevelCamera;
    public Transform sword;
    public Transform swordhitbox;
    public GameObject announcement;
    public Image colorSplash;
    private void Start()
    {

        actions = new List<Action>();
        
        actions.Add(flipCamera);
        actions.Add(zoom);
        actions.Add(speedUp);
        actions.Add(BiggerSword);
        
        actions.Add(ColorBoom);
    }


    void Update()
    {
        if (Level_Manager.instance.lost) {
            return;
        }

        timer += Time.deltaTime;
        

        if (timer >= 10)
        {
            actions[UnityEngine.Random.Range(0, actions.Count)]();
            
            timer = 0;
        }

        counter.text = Math.Floor(timer).ToString();
    }


    IEnumerator Announce(string message) {
        announcement.GetComponent<TextMeshProUGUI>().text = message;
        announcement.SetActive(true);
        yield return new WaitForSeconds(2);
        announcement.SetActive(false);
    }



    //Random Effects//
    public void flipCamera()
    {
        StartCoroutine("CameraFlip");
        StartCoroutine(Announce("Camera Flipped"));
    }

    IEnumerator CameraFlip()
    {
        //Debug.Log("Zoom");
        LevelCamera.transform.eulerAngles = new Vector3(0, 0, 180);

        yield return new WaitForSeconds(10);
        LevelCamera.transform.eulerAngles = new Vector3(0, 0, 0);
        //Debug.Log("Zoom reverted");
    }
    
    public void ColorBoom()
    {
        StartCoroutine(IColorBoom());
    }

    IEnumerator IColorBoom()
    {
        Debug.Log("ColorSplash!");
        colorSplash.gameObject.SetActive(true);
        
        colorSplash.color = new Color(UnityEngine.Random.Range(0, 1) , UnityEngine.Random.Range(0, 1) , UnityEngine.Random.Range(0, 1), .5f);
        yield return new WaitForSeconds(10);
        colorSplash.gameObject.SetActive(false);
    }
        public void zoom()
    {
        StartCoroutine("CameraZoom");
        StartCoroutine(Announce("Camera Zoomed"));
    }

    IEnumerator CameraZoom()
    {
        //Debug.Log("Zoom");
        LevelCamera.orthographicSize /= 2;

        yield return new WaitForSeconds(10);
        LevelCamera.orthographicSize *= 2;
        //Debug.Log("Zoom reverted");
    }

    public void speedUp() {
        
        StartCoroutine(SpeedDouble());
        StartCoroutine(Announce("Speed x2"));
    }

    IEnumerator SpeedDouble()
    {
        //Debug.Log("Speed x2");
        Level_Manager.instance.globalGameSpeed *= 2;

        yield return new WaitForSeconds(10);
        Level_Manager.instance.globalGameSpeed /= 2;
        //Debug.Log("Speed x2 reverted");
    }

    public void BiggerSword() {

        StartCoroutine(SwordBigger());
        StartCoroutine(Announce("Sword x2"));
    }

    IEnumerator SwordBigger()
    {
        //Debug.Log("Sword x2");

        sword.localScale = sword.localScale * 2;
        swordhitbox.localScale = sword.localScale * 2;
        sword.position = new Vector3(sword.position.x, sword.position.y + 0.6f, sword.position.z);
        swordhitbox.position = new Vector3(sword.position.x, sword.position.y + 0.6f, sword.position.z);

        yield return new WaitForSeconds(30);

        sword.localScale = sword.localScale / 2;
        swordhitbox.localScale = sword.localScale / 2;
        sword.position = new Vector3(sword.position.x, sword.position.y - 0.6f, sword.position.z);
        swordhitbox.position = new Vector3(sword.position.x, sword.position.y - 0.6f, sword.position.z);
        //Debug.Log("Sword x2 reverted");
    }


}
