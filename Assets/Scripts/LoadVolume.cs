using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
