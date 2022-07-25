using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy_Enum;

public class State_Attack : State
{
    private Enemy_Attack_Logic judge_logic; // 리턴받는 공격방식

    public override bool Judge(out State _State, Battle_Character b_c)
    {
        if (!(Vector3.Distance(b_c.transform.position,
            b_c.cur_Target.transform.position) <= b_c.Attack_Melee_Range)) // 사정 거리 내에 있다면 
        {
            judge_logic = Enemy_Attack_Logic.Melee_Attack;
            _State = this;
            return true;
        }

        if (b_c.attack_Logic[(int)Enemy_Attack_Logic.Long_Attack] == true) // 원거리 공격방식이 존재
        {
            judge_logic = Enemy_Attack_Logic.Long_Attack;
            _State = this;
            return true;
        }

        _State = Trans_List[0];
        return false;
    }

    public override void Run(Battle_Character b_c)
    {
        switch (judge_logic)
        {
            case Enemy_Attack_Logic.Melee_Attack:

                break;
            case Enemy_Attack_Logic.Long_Attack:

                break;
        }

    }
}
