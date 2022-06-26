using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Knight : Enemy
{
    // 방패를 들고 이동하고 방패를 들어올린 쪽에서 입는 데미지는 감소하기 때문에 콜라이더를 하나 더 만들어줘야함.
    void Start()
    {
        parent_Init();
        Enemy_Skill_Rand();

        StartCoroutine(Mana_Regen());
    }

    void Update()
    {
        Enemy_FSM();
    }

    protected override void Enemy_Attack()
    {
        if (Mana >= need_Mana)
        {
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    Skeleton_Knight_Skill_1();
                    break;
                case 2: // 2번 스킬
                    Skeleton_Knight_Skill_2();
                    break;
                case 3:
                    Skeleton_Knight_Skill_3();
                    break;
                    // 스킬에 따라 진행
            }
            Enemy_Skill_Rand();
        }
        else // 기본 공격
        {
            if (Vector3.Distance(transform.position, cur_Target.transform.position) <= Attack_Range) // 사정 거리 내에 있다면 
            {
                anim.SetBool("isWalk", false);
                anim.SetBool("isAttack", true);
            }
            else // 사정 거리 외에 있다면
            {
                cur_State = 2; // 추적 state로 변경
                anim.SetBool("isAttack", false);
            }
        }
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

    protected override void Enemy_Skill_Rand()
    {
        next_Skill = Random.Range(1, 4);
        Mana = 0;
    }

    void Skeleton_Knight_Skill_1() // 스켈레톤 나이트 1번스킬 
    {
        Debug.Log("강타 발동");
        // 전방을 칼로 힘껏 치는 애니메이션
    }

    void Skeleton_Knight_Skill_2() // 스켈레톤 나이트 2번스킬 
    {
        Debug.Log("방패카운터 발동");
        // 전방을 방패로 힘껏 밀어 올려치는 애니메이션
    }

    void Skeleton_Knight_Skill_3() // 스켈레톤 나이트 3번스킬 
    {
        Debug.Log("포효 발동");
        // 칼로 방패를 2번 친 후 양팔을 벌린 채 포효를 내지르는 애니메이션.
    }
}
