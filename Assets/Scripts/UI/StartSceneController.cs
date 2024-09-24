using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
