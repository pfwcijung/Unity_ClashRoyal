using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct CharacterData
{
    public string findTag;
    public float attRange;
}

public abstract class Character : MonoBehaviour
{
    public CharacterData charData = new CharacterData();
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator anim;

    void Update()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag(charData.findTag);

        if (characters.Length == 0)
            return;

        float distance = 100;
        GameObject findTarget = null;

        foreach(var character in characters)
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

        if(charData.attRange < distance)
        {
            agent.SetDestination(findTarget.transform.position);
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("idle");
            agent.SetDestination(transform.position);
            anim.SetTrigger("att");
        }

    }
}
