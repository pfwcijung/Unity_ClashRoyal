using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Transform tempParent;

    EnemyData enemyData;

    private float delayTime = 0;
    private int rand = 0;
    void Update()
    {
        if (delayTime >= 10)
            return;

        delayTime += Time.deltaTime;

        if(delayTime >= 2)
        {
            delayTime = 0;
            SetEnemyData(ControllerManager.Instance.dataCont.enemyDatas[0]);
            SpawnMonster();
        }
    }

    void SetEnemyData(EnemyData enemyData)
    {
        this.enemyData = enemyData;
    }

    void SpawnMonster()
    {
        Instantiate(enemyData.Char, tempParent);
    }
}
