using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance;

    //public CardNext cardNext;
    public UIController uiCont;
    public CardController cardCont;
    public DataController dataCont;



    void Awake()
    {
        Instance = this;
        //cardNext.Initialized();
    }
}
