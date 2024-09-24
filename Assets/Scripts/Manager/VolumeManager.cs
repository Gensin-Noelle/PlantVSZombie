using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider slider;
    public Animator anim;

    private void Start()
    {
        // 添加Slider值变化的监听器
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        // 设置Slider的初始值为当前音量值
        slider.value = AudioManager.Instance.GetVolume();
        //anim.SetFloat("volume", slider.value); //改变音量图标
    }

    private void Update()
    {
        // 更新音量图标
        if (anim != null && anim.gameObject.transform.parent.parent.gameObject.activeSelf)
        {
            anim.SetFloat("volume", AudioManager.Instance.GetVolume());
        }
    }

    // 当Slider值改变时调用的方法
    private void OnSliderValueChanged(float value)
    {
        AudioManager.Instance.SetVolume(value);
        anim.SetFloat("volume", value);
    }


}
