using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State // 스테이트 
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
    Die_Enter,
    Die,
    Die_Exit,
    Return,
    Wait,
}

[System.Serializable]
public class FSM_AI
{
    public State now_State;
    public Battle_Character battle_Character;

    public void AI_Initialize(Battle_Character bc) // AI 초기화 함수. 이 함수를 호출해서 초기화를 해줘야함.
    {
        now_State = State.Init;
        battle_Character = bc;
    }

    public State AI_Update() // 이 업데이트 함수를 호출해서 현재 State에 따라서 판단 후 판단 결과(상태)를 return 해줌.
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
                            now_State = State.Trace;
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
            case State.Attack:
                if (!(Vector3.Distance(battle_Character.transform.position, battle_Character.cur_Target.transform.position) <= battle_Character.Attack_Range)) // 사정 거리 내에 있다면 
                {
                    now_State = State.Trace;
                }
                break;
            case State.Die_Enter:
                now_State = State.Die;
                break;
            case State.Die:
                now_State = State.Wait;
                break;
            case State.Return:
                if ((Vector3.Distance(battle_Character.transform.position, battle_Character.destination_Pos) <= 0.5f)) // 사정 거리 내에 있다면 
                {
                    now_State = State.Init;
                }
                break;
        }

        // any state 
        if (battle_Character.Cur_HP <= 0 && now_State != State.Wait && now_State != State.Die)
        {
            now_State = State.Die_Enter;
        }

        return now_State;
    }

    public void Return_Set()
    {
        now_State = State.Return;
    }
}
