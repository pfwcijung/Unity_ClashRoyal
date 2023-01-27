using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Transform tempParent;

    EnemyData enemyData;

    private float cost = 0;
    private int rand = 0;

    void Start()
    {
        InvokeRepeating("SetSpawnData", 1f, 3f);
    }

    void Update()
    {
        if (cost >= 10)
            return;

        cost += Time.deltaTime;
    }

    void SetSpawnData()
    {
        rand = Random.Range(1, ControllerManager.Instance.dataCont.enemyDatas.Length);

        if (cost >= rand)
        {
            SetEnemyData(ControllerManager.Instance.dataCont.enemyDatas[rand - 1]);
            SpawnMonster();
            cost -= rand;
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
