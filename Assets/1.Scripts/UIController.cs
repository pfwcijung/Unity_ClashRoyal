using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image enegyImage;
    [SerializeField] private Image enegyDumpImage;
    [SerializeField] private TMP_Text enegyTxt;

    float curEnegy = 0;
    float maxEnegy = 10;

    public float SetcurEnegy
    {
        get { return curEnegy; }
        set
        {
            curEnegy = value;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (curEnegy <= maxEnegy)
        {
            curEnegy += Time.deltaTime;
        }

        enegyImage.fillAmount = curEnegy / maxEnegy;
        enegyDumpImage.fillAmount = (float)System.Math.Ceiling(curEnegy) / maxEnegy;
        enegyTxt.text = string.Format($"{(int)curEnegy} / {maxEnegy}");
    }
}
