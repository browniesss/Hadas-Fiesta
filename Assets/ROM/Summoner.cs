using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
   
    void Start()
    {
        parent_Init();
    }

    protected override void Enemy_FSM()
    {
        switch (cur_State)
        {
            case 1:
                Enemy_Patrol();
                break;
            case 2:
                Enemy_Trace();
                break;
            case 3:
                Enemy_Attack();
                break;
            case 4:
                Enemy_Return();
                break;
        }
    }

    protected override void Enemy_Attack()
    {
        if (Mana >= need_Mana)
        {
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    break;
                case 2: // 2번 스킬
                    break;
                    // 스킬에 따라 진행
            }
        }
        else // 기본 공격
        {
            if (Vector3.Distance(transform.position, cur_Target.transform.position) <= Attack_Range) // 사정 거리 내에 있다면 
            {
                anim.SetBool("isWalk", false);
                anim.SetTrigger("isAttack");
            }
            else // 사정 거리 외에 있다면
            {
                cur_State = 2; // 추적 state로 변경
            }
        }
    }

    void Update()
    {
        Enemy_FSM();
    }
}
