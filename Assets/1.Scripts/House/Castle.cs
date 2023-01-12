using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [SerializeField] public float setCastleHp = 0;
    [SerializeField] private Image curHpImage;
    [SerializeField] private Image maxHpImage;
    [SerializeField] private float castleCurHp = 0;
    [SerializeField] private float castleMaxHp = 0;

    void Start()
    {
        castleCurHp = castleMaxHp = setCastleHp;
        curHpImage.enabled = false;
        maxHpImage.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            curHpImage.enabled = true;
            maxHpImage.enabled = true;
            castleCurHp -= 100;
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            castleCurHp += 100;
        }

        curHpImage.fillAmount = (castleCurHp / castleMaxHp);
    }
}
