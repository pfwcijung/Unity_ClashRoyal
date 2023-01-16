using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
    void Start()
    {
        charData.findTag = "enemy";
        charData.attRange = 1f;
    }
}
