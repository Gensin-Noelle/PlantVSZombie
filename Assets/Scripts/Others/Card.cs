using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum CardState
{
    Disable,
    Colling,
    Ready,
    WaitingSun
}

public enum PlantType
{
    SunFlower,
    PeaShooter,
    Wallnut,
    Repeater,
    Jalapeno,
    SnowPea,
    FlamePea
}
public class Card : MonoBehaviour
{
    public GameObject cardLight;
    public GameObject cardGray;
    public Image maskImage;
    public PlantType plantType = PlantType.SunFlower;
    public float cdTime = 2;
    private float cdTimer = 0;
    [SerializeField]
    private int needSunPoint = 50;
    private CardState cardState = CardState.Disable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (cardState)
        {
            case CardState.Ready:
                ReadyUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Colling:
                CoolingUpdate();
                break;
        }
    }

    private void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;
        maskImage.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime)
        {
            TransitionToWaitingSun();
        }
    }

    private void ReadyUpdate()
    {
        if (needSunPoint <= SunManager.Instance.SunPoint)
        {
            TransitionToReady();
        }
        else
        {
            TransitionToWaitingSun();
        }
    }

    private void WaitingSunUpdate()
    {
        if (needSunPoint <= SunManager.Instance.SunPoint)
        {
            TransitionToReady();
        }
    }

    private void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;

        cardLight.SetActive(false);
        cardGray.SetActive(true);
        maskImage.gameObject.SetActive(false);
    }

    private void TransitionToCooling()
    {
        cardState = CardState.Colling;

        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        maskImage.gameObject.SetActive(true);
    }

    private void TransitionToReady()
    {
        cardState = CardState.Ready;

        cardLight.SetActive(true);
        cardGray.SetActive(false);
        maskImage.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        AudioManager.Instance.PlayClip(Config.button_click);
        if (needSunPoint > SunManager.Instance.SunPoint) return;
        //消耗阳光值，并进行种植
        bool isSuccess = HandManager.Instance.AddPlant(plantType);
        if (isSuccess)
        {
            SunManager.Instance.SubSun(needSunPoint);
            TransitionToCooling();
        }
    }

    public void DisableCard()
    {
        cardState = CardState.Disable;
    }

    public void EnableCard()
    {
        TransitionToCooling();
    }
}
