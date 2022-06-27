using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Warrior : Enemy
{
    void Start()
    {
        parent_Init();
        Enemy_Skill_Rand();

        StartCoroutine(Mana_Regen());
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

    void Update()
    {
        Enemy_FSM();

        if (Input.GetKeyDown(KeyCode.F3))
            Enemy_Die();
    }

    protected override void Enemy_Attack()
    {
        if (Mana >= need_Mana)
        {
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    Skeleton_Warrior_Skill_1();
                    break;
                case 2: // 2번 스킬
                    Skeleton_Warrior_Skill_2();
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

    protected override void Enemy_Skill_Rand()
    {
        next_Skill = Random.Range(1, 3);
        Mana = 0;
    }

    protected override void Enemy_Die()
    {
        enemy_isDie = true;
        cur_State = -1;

        AnimatorControllerParameter[] parameters = anim.parameters;

        foreach (var parameter in parameters)
        {
            anim.SetBool(parameter.name, false);
        }
        anim.SetBool("isDie", true);

        StartCoroutine(Skeleton_Warrior_Revival());
    }

    IEnumerator Skeleton_Warrior_Revival()
    {
        yield return new WaitForSeconds(5f);

        anim.SetBool("isDie", false);

        yield return new WaitForSeconds(2f);
        enemy_isDie = false;
        cur_State = 1;
    }

    void Skeleton_Warrior_Skill_1() // 스켈레톤 워리어 1번스킬 내려치기
    {
        Debug.Log("내려치기 발동");
    }

    void Skeleton_Warrior_Skill_2() // 스켈레톤 워리어 2번스킬 찌르기
    {
        Debug.Log("찌르기 발동");
    }
}
