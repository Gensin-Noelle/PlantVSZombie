using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchToStartScene()
    {
        SceneManager.LoadScene("SatrtScene");
    }

    public void SwitchToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SwitchToScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void PauseGame()
    {
        if (GameManager.Instance.GetIsGameOver())
        {
            return;
        }
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        if (GameManager.Instance.GetIsGameOver())
        {
            return;
        }
        Time.timeScale = 1;
    }
}
