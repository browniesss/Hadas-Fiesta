using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General_Monster_State : State_Handler
{
    public override void State_Handler_Update()
    {
        switch (state)
        {
            case State.Patrol_Enter:
                Patrol_Enter_Process();
                break;
            case State.Patrol:
                Patrol_Process();
                break;
            case State.Trace:
                Trace_Process();
                break;
            case State.Attack:
                Attack_Process();
                break;
        }
    }


    protected override void Patrol_Enter_Process()
    {
        battle_Character.patrol_Start = false;
    }

    protected override void Patrol_Process()
    {
        if (Vector3.Distance(battle_Character.transform.position, battle_Character.destination_Pos) == 0f)
        {
            if (!battle_Character.patrol_Start)
            {
                StartCoroutine(patrol_Think_Coroutine());
                battle_Character.patrol_Start = true;
            }
        }
        else
        {
            Destination_Move(battle_Character.destination_Pos);
        }
    }

    protected override void Patrol_Exit_Process()
    {

    }


    protected override void Trace_Process()
    {
        Destination_Move(battle_Character.cur_Target.transform.position);
    }

    protected override void Attack_Process()
    {

    }
}
