using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image enegyImage;
    [SerializeField] private TMP_Text enegyTxt;

    float curEnegy = 0;
    float maxEnegy = 10;
    float delayTime = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (curEnegy < maxEnegy)
        {
            delayTime += Time.deltaTime;
            if (delayTime > 1f)
            {
                curEnegy += 1;
                delayTime = 0;
            }
        }

        enegyImage.fillAmount = curEnegy / maxEnegy;
        enegyTxt.text = string.Format($"{curEnegy} / {maxEnegy}");
    }
}
