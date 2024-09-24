using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private float volume = 1;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //由GameManager统一管理
        //PlayBgm(Config.bgm1);
    }

    public void PlayBgm(string path)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(path);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayClip(string path, float volume = 1.0f)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(path);
        Vector3 cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, cameraPosition, volume);
    }

    public void PlayClip(string path)
    {
        AudioClip audioClip = Resources.Load<AudioClip>(path);
        Vector3 cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, cameraPosition, volume);
    }

    public void SetVolume(float volume)
    {
        this.volume = volume;
        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }

}
