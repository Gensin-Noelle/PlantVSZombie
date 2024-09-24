using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainCamera;
    public PrepareUI prepareUI;
    public CardListUI cardListUI;
    public FailUI failUI;
    public WinUI winUI;
    public static GameManager Instance { get; private set; }
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStart();
    }

    private void GameStart()
    {
        StartCoroutine(MyTools.MoveToTarget(mainCamera, new Vector3(3.4f, 0, -10)));
        Invoke(nameof(DelayCameraReturn), 2);
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;
        failUI.Show(); //显示游戏结束UI
        AudioManager.Instance.PlayClip(Config.lose_music);
    }

    public void GameCompletion()
    {
        if (isGameOver)
        {
            return;
        }
        //处理游戏胜利逻辑
        isGameOver = true;
        winUI.Show();
        AudioManager.Instance.PlayClip(Config.win_music);

    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    private void DelayCameraReturn()
    {
        StartCoroutine(MyTools.MoveToTarget(mainCamera, new Vector3(-2, 0, -10)));
        Invoke(nameof(ShowPrepareUI), 1);
    }

    private void ShowPrepareUI()
    {
        prepareUI.Show(OnPrepareUIComplete);
    }

    private void OnPrepareUIComplete()
    {
        SunManager.Instance.StartProduce();
        ZombieManager.Instance.StratSpawn();
        cardListUI.ShowCardList();
        AudioManager.Instance.PlayBgm(Config.bgm1);
    }
}
