using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform tempParent;
    [SerializeField] public Transform cardTempParent;
    public GameObject[] cards;

    float delayTime = 0;

    void Update()
    {
        if (cards.Length > 4)
            return;

        delayTime += Time.deltaTime;

        if (delayTime >= 1f)
        {
            Instantiate(prefab, tempParent);
            delayTime = 0;
        }
    }
}
