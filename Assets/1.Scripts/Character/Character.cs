using System.Collections;
using System.Collections.Generic;
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
    private float deadTime = 0;

    void Start()
    {
        if (gameObject.tag.Equals("my"))
            curHp = cardData.Hp;
        else if (gameObject.tag.Equals("enemy"))
            curHp = enemyData.Hp;
    }

    void Update()
    {
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

        if (gameObject.tag.Equals("my"))
        {
            MyMonsAct(findTarget);
        }
        else if (gameObject.tag.Equals("enemy"))
        {
            EnemyMonsAct(findTarget);
        }
        

    }

    void Damage(float damage)
    {
        if(curHp <= 0)
        {
            deadTime += Time.deltaTime;
            Debug.Log(deadTime);
            Destroy(gameObject);

            gameObject.tag = "Untagged";
            anim.SetTrigger("dead");


            //if (deadTime > 1f) 
        }

        curHp -= damage;
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

            if (cardData.AttDelay < delayTime)
            {
                anim.SetTrigger("att");
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

            if (enemyData.AttDelay < delayTime)
            {
                anim.SetTrigger("att");
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
