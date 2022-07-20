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
            case State.Return:
                Return_Process();
                break;
            case State.Die:
                Die_Process();
                break;
        }
    }

    protected override void Patrol_Enter_Process()
    {
        battle_Character.patrol_Start = false;
    }

    protected override void Patrol_Process()
    {
        Vector3 charPos = new Vector3(battle_Character.transform.position.x, 0, battle_Character.transform.position.z);
        Vector3 desPos = new Vector3(battle_Character.destination_Pos.x, 0, battle_Character.destination_Pos.z);

        if (Vector3.Distance(charPos, desPos) <= 1f)
        {
            if (!battle_Character.patrol_Start)
            {
                StartCoroutine(patrol_Think_Coroutine());
                battle_Character.patrol_Start = true;

                //anim.SetBool("isWalk", false);
            }
        }
        else
        {
            Destination_Move(battle_Character.destination_Pos);

            //anim.SetBool("isWalk", true);
        }
    }

    protected override void Patrol_Exit_Process()
    {

    }

    protected override void Trace_Process()
    {
        Destination_Move(battle_Character.cur_Target.transform.position);

        //anim.SetBool("isWalk", true);
    }

    protected override void Return_Process()
    {
        Destination_Move(battle_Character.return_Pos);

        //anim.SetBool("isReturn", true);
    }

    protected override void Attack_Process()
    {
        battle_Character.Attack_Process();
    }

    protected override void Die_Process()
    {
        battle_Character.Die_Process();

        //anim.SetBool("isDie", true);
    }
}
