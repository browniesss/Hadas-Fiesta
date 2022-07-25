using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Init : State
{

    public override bool Judge(out State _State, Battle_Character b_c)
    {
        _State = Trans_List[0];
        return false;
    }

    public override void Run(Battle_Character b_c)
    {

    }
}
