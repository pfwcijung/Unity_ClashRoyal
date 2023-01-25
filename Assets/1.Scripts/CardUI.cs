using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;
using Unity.VisualScripting;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Transform tempParent;
    [SerializeField] TMP_Text costTxt;

    private int CardIndex = 0;
    private int cost = 0;

    CardData cardData;
    void Update()
    {
        costTxt.text = string.Format($"{cost}");
    }

    void SpawnMonster()
    {
        Instantiate(cardData.Char, tempParent);
    }
    public void SetCost(int money)
    {
        cost = money;
    }

    public void SetParent(Transform trans)
    {
        tempParent = trans;
    }

    public void SetIndex(int index)
    {
        CardIndex = index;
    }

    public CardUI SetCardData(CardData cardData)
    {
        this.cardData = cardData;

        return this;
    }

    public void OnClick()
    {
        if (ControllerManager.Instance.uiCont.SetcurEnegy < cost)
            return;

        ControllerManager.Instance.cardCont.DestroyCard(CardIndex);
        ControllerManager.Instance.uiCont.SetcurEnegy -= cost;

        SpawnMonster();
        Destroy(gameObject);
    }
}
