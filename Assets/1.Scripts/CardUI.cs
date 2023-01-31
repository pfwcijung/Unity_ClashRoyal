using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngineInternal;

public class CardUI : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] private Transform tempParent;
    [SerializeField] TMP_Text costTxt;
    [SerializeField] Canvas canvas;

    private int CardIndex = 0;
    private int cost = 0;

    CardData cardData;

    void start()
    {

    }

    RaycastHit hit;
    void Update()
    {
        costTxt.text = string.Format($"{cost}");

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100)) 
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
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

    public void SetDataCanvas (Canvas canvas)
    {
        this.canvas = canvas;
    }

    public void OnClick()
    {
        /*
        if (ControllerManager.Instance.uiCont.SetcurEnegy < cost)
            return;

        ControllerManager.Instance.cardCont.DestroyCard(CardIndex);
        ControllerManager.Instance.uiCont.SetcurEnegy -= cost;

        SpawnMonster();
        Destroy(gameObject);
        */
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // 카드를 원래 자리로 돌려야함
        if (hit.transform == null)
        {
            ControllerManager.Instance.cardCont.ReturnCardPos(this);
            return;
        }

        if (ControllerManager.Instance.uiCont.SetcurEnegy < cost)
            return;

        if (hit.transform.tag.Equals("ray"))
        {
            ControllerManager.Instance.cardCont.DestroyCard(CardIndex);
            ControllerManager.Instance.uiCont.SetcurEnegy -= cost;
            tempParent.position = new Vector3(hit.point.x, 0.5f, hit.point.z);
            SpawnMonster();
            Destroy(gameObject);
        }
    }
}
