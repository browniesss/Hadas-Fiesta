using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _State // 스테이트 
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
    Next_Wait, 
}

/*
 다음 스킬을 어떤 패턴, 어떤 방식으로 굴러가야 하는지 검사하는것도 해줘야함.
어떤 패턴뒤에는 어떤 패턴이 안나오고 이런식이 있을 수 있기 때문에
 */

[System.Serializable]
public class FSM_AI
{
    public _State now_State;
    public Battle_Character battle_Character;

    public void AI_Initialize(Battle_Character bc) // AI 초기화 함수. 이 함수를 호출해서 초기화를 해줘야함.
    {
        now_State = _State.Init;
        battle_Character = bc;
    }

    public _State AI_Update() // 이 업데이트 함수를 호출해서 현재 State에 따라서 판단 후 판단 결과(상태)를 return 해줌.
    {
        switch (now_State)
        {
            case _State.Init:
                now_State = _State.Patrol_Enter;
                break;
            case _State.Patrol_Enter:
                now_State = _State.Patrol;
                break;
            case _State.Patrol:
                Collider[] cols = Physics.OverlapSphere(battle_Character.transform.position, battle_Character.mon_find_Range);
                //, 1 << 8); // 비트 연산자로 8번째 레이어

                if (cols.Length > 0)
                {
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (cols[i].tag == "Player")
                        {
                            battle_Character.cur_Target = cols[i].gameObject;
                            now_State = _State.Trace;
                        }
                    }
                }
                break;
            case _State.Trace:
                if (Vector3.Distance(battle_Character.transform.position, battle_Character.cur_Target.transform.position) <= battle_Character.Attack_Melee_Range) // 타겟에 닿았다면
                {
                    now_State = _State.Attack; // 공격 상태로 변경
                }
                break;
            case _State.Attack:
                if (!(Vector3.Distance(battle_Character.transform.position, battle_Character.cur_Target.transform.position) <= battle_Character.Attack_Melee_Range)) // 사정 거리 내에 있다면 
                {
                    now_State = _State.Trace;
                }
                break;
            case _State.Die_Enter:
                now_State = _State.Die;
                break;
            case _State.Die:
                now_State = _State.Wait;
                break;
            case _State.Return:
                if ((Vector3.Distance(battle_Character.transform.position, battle_Character.return_Pos) <= 0.5f)) // 사정 거리 내에 있다면 
                {
                    now_State = _State.Init;
                }
                break;
        }

        // any state 
        if (battle_Character.Cur_HP <= 0 && now_State != _State.Wait && now_State != _State.Die)
        {
            now_State = _State.Die_Enter;
        }

        return now_State;
    }

    public void Return_Set()
    {
        now_State = _State.Return;
    }
}
