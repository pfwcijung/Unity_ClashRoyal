using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public struct CharacterData
{
    public string findTag;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator anim;
    public CardData cardData;
    public EnemyData enemyData;
    private float delayTime = 0;
    private float distance = 0;
    private float curHp = 1;
    private float damageDelayTime = 0;

    void Start()
    {
        if (gameObject.tag.Equals("my"))
        {
            curHp = cardData.Hp;
            agent.speed = cardData.Speed;
        }
        else if (gameObject.tag.Equals("enemy"))
        {
            curHp = enemyData.Hp;
            agent.speed = enemyData.Speed;
        }
    }

    void Update()
    {
        if (curHp <= 0)
        {
            return;
        }

        GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.findTag);

        if (characters.Length == 0)
            return;

        GameObject findTarget = null;

        distance = 100;

        foreach (var character in characters)
        {
            float dis = Vector3.Distance(agent.transform.position, character.transform.position);
            if (distance > dis)
            {
                findTarget = character;
                distance = dis;
            }
        }

        if (findTarget == null)
            return;

        damageDelayTime += Time.deltaTime;

        if (gameObject.tag.Equals("my"))
        {
            MyMonsAct(findTarget);
        }
        else if (gameObject.tag.Equals("enemy"))
        {
            EnemyMonsAct(findTarget);
        }
        

    }
    public void Damage(float damage)
    {
        if (damageDelayTime < 1f)
            return;

        curHp -= damage;
        damageDelayTime = 0;

        if(curHp <= 0)
        {
            agent.enabled = false;
            agent.SetDestination(transform.position);
            gameObject.tag = "Untagged";
            anim.SetTrigger("dead");
            Destroy(gameObject, 2f);
        }

    }

    private void MyMonsAct(GameObject findTarget)
    {
        if (cardData.AttRange < distance)
        {
            agent.SetDestination(findTarget.transform.position);
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("idle");
            agent.SetDestination(transform.position);

            delayTime += Time.deltaTime;

            anim.SetTrigger("att");

            if (cardData.AttDelay < delayTime)
            {
                delayTime = 0;

                if(findTarget.GetComponent<Castle>() != null)
                {
                    findTarget.GetComponent<Castle>().Damage(cardData.Damage);
                }
                else if(findTarget.GetComponent<Character>() != null)
                {
                    findTarget.GetComponent<Character>().Damage(cardData.Damage);
                }
            }
        }
    }
    private void EnemyMonsAct(GameObject findTarget)
    {
        if (enemyData.AttRange < distance)
        {
            agent.SetDestination(findTarget.transform.position);
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("idle");
            agent.SetDestination(transform.position);

            delayTime += Time.deltaTime;

            anim.SetTrigger("att");

            if (enemyData.AttDelay < delayTime)
            {
                delayTime = 0;

                if (findTarget.GetComponent<Castle>() != null)
                {
                    findTarget.GetComponent<Castle>().Damage(enemyData.Damage);
                }
                else if (findTarget.GetComponent<Character>() != null)
                {
                    findTarget.GetComponent<Character>().Damage(enemyData.Damage);
                }
            }
        }
    }
}
