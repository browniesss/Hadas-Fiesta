using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Monster : Battle_Character
{
    void Start()
    {
        Initalize();
        ai.AI_Initialize(this);
    }

    void Update()
    {
        state_handler.state = ai.AI_Update();
        state_handler.State_Handler_Update();
    }

    public override void Skill_1() // 선발 돌격대 1번스킬 찌르기
    {
        Debug.Log("돌진 찌르기 발동");
        state_handler.navMesh.speed *= 3f;
    }

    public override void Die_Process() // 죽을때 호출되는 함수
    {

    }

    public override void Attack_Process()
    {
        if (Player_Mana >= need_Mana)
        {
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    Skill_1();
                    break;
                    // 스킬에 따라 진행
            }
            //Enemy_Skill_Rand(); // 다음 스킬 찾기
        }
        else // 기본 공격
        {
            // 기본 공격 코드
            //anim.SetBool("isAttack", true);
        }
    }
}
