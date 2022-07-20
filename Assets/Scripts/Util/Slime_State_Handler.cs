using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_State_Handler : State_Handler
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
            case State.Attack: // 슬라임은 붙어있는 상태
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
        if (battle_Character.GetComponent<Slime>().OnTree)
            return;

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
        if (battle_Character.GetComponent<Slime>().OnTree)
        {
            Vector3 dirVec = battle_Character.cur_Target.transform.position - battle_Character.transform.position;
            battle_Character.GetComponent<Rigidbody>().AddForce(dirVec * 10f * Time.deltaTime, ForceMode.Impulse);

            battle_Character.GetComponent<Slime>().OnTree = false;
        }
        else
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
        if (battle_Character.Player_Mana >= battle_Character.need_Mana)
        {
            switch (battle_Character.next_Skill)
            {
                case 1: // 1번 스킬
                    battle_Character.Skill_1();
                    break;
                    // 스킬에 따라 진행
            }
            Enemy_Skill_Rand();
        }
        else // 기본 공격
        {
            // 기본 공격 코드
            //anim.SetBool("isAttack", true);
        }
    }

    protected override void Die_Process()
    {
        battle_Character.Die_Process();

        //anim.SetBool("isDie", true);
    }
}
