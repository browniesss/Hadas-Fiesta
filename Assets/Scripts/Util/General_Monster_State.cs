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
        if (battle_Character.Player_Mana >= battle_Character.need_Mana)
        {
            switch (battle_Character.next_Skill)
            {
                case 1: // 1번 스킬
                    battle_Character.Skill_1();
                    break;
                case 2: // 2번 스킬
                    battle_Character.Skill_2();
                    break;
                    // 스킬에 따라 진행
            }
            Enemy_Skill_Rand();
        }
        else // 기본 공격
        {
            // 기본 공격 코드


        }
    }

    protected override void Die_Process()
    {
        battle_Character.Die_Process();
    }
}
