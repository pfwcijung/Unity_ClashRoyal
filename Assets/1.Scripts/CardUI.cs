using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private Transform tempParent;
    [SerializeField] TMP_Text costTxt;

    public int CardIndex = 0;
    public int cost = 0;
    void Start()
    {
        cost = Random.Range(1, 9);
    }

    void Update()
    {
        costTxt.text = string.Format($"{cost}");
    }

    void SpawnMonster()
    {
        Instantiate(prefab, tempParent);
    }

    public void SetParent(Transform trans)
    {
        tempParent = trans;
    }

    public void SetIndex(int index)
    {
        CardIndex = index;
    }

    public void OnClick()
    {
        SpawnMonster();

        ControllerManager.Instance.cardCont.DestroyCard(CardIndex);

        Destroy(gameObject);
    }
}
