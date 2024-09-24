using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListUI : MonoBehaviour
{
    public List<Card> cardList;

    private void Start()
    {
        DisableCardList();
        // 由GameManager控制卡片槽的显示
        // ShowCardList();
    }

    public void ShowCardList()
    {
        // 移动卡片槽，并在移动完成后启用卡片列表
        StartCoroutine(MyTools.MoveToTarget(gameObject, transform.position + new Vector3(0, -143, 0), () =>
        {
            EnableCardList(); // 在移动完成后调用回调函数来启用卡片列表
        }));
    }

    private void DisableCardList()
    {
        foreach (Card card in cardList)
        {
            card.DisableCard();
        }
    }

    private void EnableCardList()
    {
        foreach (Card card in cardList)
        {
            card.EnableCard();
        }
    }
}
