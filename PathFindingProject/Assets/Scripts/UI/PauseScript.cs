using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    public static bool isPaused { get { return Time.timeScale == 0; } }
    public GameObject PauseMenu;
    void Start() {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause(!isPaused);

    }

    void Pause(bool pause)
    {
        Time.timeScale = !isPaused ? 0 : 1;
        PauseMenu.SetActive(isPaused);
    }

    public void Resume() { Pause(false); }

}
