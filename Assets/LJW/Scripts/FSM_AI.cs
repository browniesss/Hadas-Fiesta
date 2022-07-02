using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Init,
    Patrol_Enter,
    Patrol,
    Patrol_Exit,
    Trace_Enter,
    Trace,
    Trace_Exit,
    Attack_Enter,
    Attack,
    Attack_Exit,
}

[System.Serializable]
public class FSM_AI
{
    public State now_State;
    public Battle_Character battle_Character;

    public void AI_Initialize(Battle_Character bc)
    {
        now_State = State.Init;
        battle_Character = bc;
    }

    public State AI_Update()
    {
        switch (now_State)
        {
            case State.Init:
                now_State = State.Patrol_Enter;
                break;
            case State.Patrol_Enter:
                now_State = State.Patrol;
                break;
            case State.Patrol:
                Collider[] cols = Physics.OverlapSphere(battle_Character.transform.position, 10f);
                //, 1 << 8); // 비트 연산자로 8번째 레이어

                if (cols.Length > 0)
                {
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (cols[i].tag == "Player")
                        {
                            battle_Character.cur_Target = cols[i].gameObject;
                            now_State = State.Trace_Enter;
                        }
                    }
                }
                break;
            case State.Trace:
                if (Vector3.Distance(battle_Character.transform.position, battle_Character.cur_Target.transform.position) <= battle_Character.Attack_Range) // 타겟에 닿았다면
                {
                    now_State = State.Attack; // 공격 상태로 변경
                }
                break;
        }

        return now_State;
    }
}
