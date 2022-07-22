using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_State_Handler : State_Handler
{
    [SerializeField]
    private Slime slime_component;

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
            case State.Next_Wait:
                Next_Wait_Process();
                break;
            case State.Return:
                Return_Process();
                break;
            case State.Die:
                Die_Process();
                break;
        }
    }

    public override void State_Handler_Initialize(Battle_Character b_c) // 스테이트 처리기 초기화 함수
    {
        base.State_Handler_Initialize(b_c);

        slime_component = battle_Character.GetComponent<Slime>();
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
            //Vector3 dirVec = battle_Character.cur_Target.transform.position - battle_Character.transform.position;
            //battle_Character.GetComponent<Rigidbody>().AddForce(dirVec * 10f * Time.deltaTime, ForceMode.Impulse);

            Vector3 dirvec = battle_Character.cur_Target.transform.position - transform.position;
            dirvec += new Vector3(0, 8, 0);

            GetComponent<Rigidbody>().AddForce(dirvec * 350f);

            battle_Character.GetComponent<Slime>().OnTree = false;
        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.5f, LayerMask.GetMask("Ground")))
            {
                if (!navMesh.enabled)
                {
                    navMesh.enabled = true;
                    battle_Character.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }

            }

            Destination_Move(battle_Character.cur_Target.transform.position);

            //anim.SetBool("isWalk", true);
        }
    }
    protected override void Return_Process()
    {
        Destination_Move(battle_Character.return_Pos);

        //anim.SetBool("isReturn", true);
    }

    protected override void Attack_Process()
    {

        if (battle_Character.Player_Mana >= battle_Character.need_Mana && slime_component.attached_Player == null)
        {
            Debug.Log("스킬발동");
            battle_Character.Skill_1();
        }
        else if (slime_component.attached_Player != null)
        {
            //battle_Character.transform.position = slime_component.attached_Player.transform.position + slime_component.offset;
        }
    }

    void Next_Wait_Process()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground")))
        {
            if (!navMesh.enabled)
            {
                navMesh.enabled = true;
                battle_Character.GetComponent<Rigidbody>().velocity = Vector3.zero;

                battle_Character.ai.now_State = State.Patrol_Enter;
            }
        }
    }

    protected override void Die_Process()
    {
        battle_Character.Die_Process();

        //anim.SetBool("isDie", true);
    }
}
