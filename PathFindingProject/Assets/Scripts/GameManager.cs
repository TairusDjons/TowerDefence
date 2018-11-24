using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Castle castle;
    public WaveGenerator generator;
    public GameObject GameOverMenu;
    public GameObject WinMenu;

    public static GameManager instance;
    
	// Use this for initialization
	void Start () {
        instance = this;
        castle.Death += GameOver;
        generator.End += WinFunc;
	}

    public void WinFunc()
    {
        WinMenu.SetActive(true);
        StartCoroutine(SlowDownGame());
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        StartCoroutine(SlowDownGame());
    }

    IEnumerator SlowDownGame()
    {
        while (Time.timeScale > 0)
        {
            Time.timeScale -= Time.deltaTime / 2;
            yield return 0;
        }
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

