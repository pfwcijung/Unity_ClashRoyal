using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "MyCardData/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] Character character;
    public Character Char { get { return character; } }

    [SerializeField] int speed;
    public int Speed { get { return speed; } }

    [SerializeField] int cost;
    public int Cost { get { return cost; } }

    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] float attDelay;
    public float AttDelay { get { return attDelay; } }

    [SerializeField] float attRange;
    public float AttRange { get { return attRange; } }

    [SerializeField] float hp;
    public float Hp { get { return hp; } }
}
