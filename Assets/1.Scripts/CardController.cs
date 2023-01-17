using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardUI prefab;
    [SerializeField] private Transform tempParent;
    [SerializeField] public Transform cardTempParent;
    public List<CardUI> cards = new List<CardUI>(); 

    float delayTime = 0;
    public int cardIdx = 0;
    private int[] ableCard = new int[4];

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            CardUI card = Instantiate(prefab, tempParent);
            card.SetParent(cardTempParent);
            card.SetIndex(cardIdx);
            cards.Add(card);
            ableCard[cardIdx] = 1;
            cardIdx++;
            delayTime = 0;
        }     
    }
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if (ableCard[i] == 0)
            {
                delayTime += Time.deltaTime;

                if (delayTime >= 1f)
                {
                    CardUI card = Instantiate(prefab, tempParent);
                    card.SetParent(cardTempParent);
                    cards.Add(card);
                    delayTime = 0;
                    ableCard[i] = 1;
                }
            }
        }
    }

    public void DestroyCard(int index)
    {
        cards.RemoveAt(index);
        ableCard[index] = 0;
    }
}
