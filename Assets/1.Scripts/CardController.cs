using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private CardUI prefab;
    [SerializeField] private Transform tempParent;
    [SerializeField] public Transform cardTempParent;
    //°í¹Î
    public GameObject[] cards = new GameObject[4];

    float delayTime = 0;

    void Update()
    {
        if (cards.Length > 4)
            return;

        delayTime += Time.deltaTime;

        if (delayTime >= 1f)
        {
            Instantiate(prefab, tempParent).SetParent(cardTempParent);
            delayTime = 0;
        }
    }
}
