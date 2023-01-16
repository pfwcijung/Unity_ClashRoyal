using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform tempParent;

    void Start()
    {

    }

    void SpawnMonster()
    {
        Instantiate(prefab, tempParent);
    }

    public void SetParent(Transform trans)
    {
        tempParent = trans;
    }

    public void OnClick()
    {
        SpawnMonster();
    }
}
