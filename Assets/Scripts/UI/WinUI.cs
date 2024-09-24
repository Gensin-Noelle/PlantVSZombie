using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    public void Show()
    {
        anim.enabled = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
