using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailUI : MonoBehaviour
{
    private Animator anim;

    private void Start()
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
        //实现暂停游戏，由动画帧事件调用(FailUI)
        Time.timeScale = 0;
    }
}
