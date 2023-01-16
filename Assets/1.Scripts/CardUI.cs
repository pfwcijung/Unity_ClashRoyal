using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform tempParent;

    void Start()
    {
        tempParent = GetComponent<CardController>().cardTempParent;
    }

    void SpawnMonster()
    {
        Instantiate(prefab, tempParent.transform);
    }

    public void OnClick()
    {
        SpawnMonster();
    }
}
