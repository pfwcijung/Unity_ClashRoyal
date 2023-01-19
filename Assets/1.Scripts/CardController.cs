using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardUI prefab;
    [SerializeField] private Transform tempParent;
    [SerializeField] public Transform cardTempParent;
    [SerializeField] private Transform nextTempParent;
    public List<CardUI> cards = new List<CardUI>();
    public CardUI nextCard;

    float delayTime = 0;
    public int cardIdx = 0;
    public int cost = 0;
    public int nextCost = 0;
    public Transform target;
    private int[] ableCard = new int[4];
    void Start()
    {
        MakeFirstCard();
        MakeNextCard();
    }
    void Update()
    {
        if (cards.Count >= 4)
            return;


        delayTime += Time.deltaTime;

        if (delayTime >= 1f)
        {
            for (int i = 0; i < 4; i++)
            {
                if (ableCard[i] == 0)
                {
                    nextCost = cost;
                    CardUI card = Instantiate(prefab, tempParent);
                    card.SetParent(cardTempParent);
                    card.SetCost(nextCost);
                    card.SetCardData(ControllerManager.Instance.dataCont.datas[cost - 1]);
                    cards.Add(card);
                    delayTime = 0;
                    ableCard[i] = 1;
                    DestoryNextCard(nextCard.transform.gameObject);
                    MakeNextCard();
                }
            }

        }
    }
    public void MakeFirstCard()
    {
        for (int i = 0; i < 4; i++)
        {
            CardUI card = Instantiate(prefab, tempParent);
            cost = Random.Range(1, ControllerManager.Instance.dataCont.datas.Length + 1);
            card.SetParent(cardTempParent);
            card.SetCost(cost);
            card.SetCardData(ControllerManager.Instance.dataCont.datas[cost - 1]);
            cards.Add(card);
            ableCard[cardIdx] = 1;
            cardIdx++;
            delayTime = 0;
        }
    }

    public void MakeNextCard()
    {
        CardUI nextCard = Instantiate(prefab, nextTempParent);
        cost = Random.Range(1, ControllerManager.Instance.dataCont.datas.Length);
        nextCard.SetCost(cost);
        nextCard.SetCardData(ControllerManager.Instance.dataCont.datas[cost - 1]);
        this.nextCard = nextCard;
    }

    public void DestoryNextCard(GameObject gameobj)
    {
        Destroy(gameobj);
    }

    public void DestroyCard(int index)
    {
        cards.RemoveAt(index);
        ableCard[index] = 0;
    }
}
