using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpBehavior  
{
    bool Jump
    {
        get;
        set;
    }
    void Pular();
}
