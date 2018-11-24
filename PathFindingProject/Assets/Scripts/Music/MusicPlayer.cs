using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {

    public AudioSource bgm;
    // Use this for initialization
    void Start()
    {
  
    }

    // Update is called once per frame
    void Awake()
    {
        GameObject currentBGM = GameObject.FindGameObjectWithTag("GameMusic");
        if (currentBGM == null)
        {
            AudioSource spawned = Instantiate(bgm);
            spawned.Play();
            DontDestroyOnLoad(spawned);
        }
    }
}
