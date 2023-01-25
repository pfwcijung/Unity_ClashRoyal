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

    public void Damage(float damage)
    {
        castleCurHp -= damage;
        if(castleCurHp <= 0)
        {
            curHpImage.enabled = false;
            maxHpImage.enabled = false;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        castleCurHp = castleMaxHp = setCastleHp;
        //curHpImage.enabled = false;
        //maxHpImage.enabled = false;
    }
    void Update()
    {
        curHpImage.fillAmount = (castleCurHp / castleMaxHp);
    }
}
