using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform tempParent;

    void SpawnMonster()
    {
        Instantiate(prefab, tempParent.transform);
    }

    public void OnClick()
    {
        SpawnMonster();
    }
}
