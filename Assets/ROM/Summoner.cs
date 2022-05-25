using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{

    public GameObject SusuPrefabs;
    public GameObject ShootingStarPrefabs;


    void Start()
    {
        parent_Init();
    }

    void Attack_Mana()
    {
        Mana += 5;
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
            next_Skill = Random.Range(1, 3);
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    susu_Summons();
                    break;
                case 2: // 2번 스킬
                    ShootingStar();
                    break;
                    // 스킬에 따라 진행
            }
            Mana = 0;

        }
        else // 기본 공격
        {
            if (Vector3.Distance(transform.position, cur_Target.transform.position) <= Attack_Range) // 사정 거리 내에 있다면 
            {
                anim.SetBool("isWalk", false);
                anim.SetTrigger("isAttack");
                //Attack_Mana();
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


    void susu_Summons()
    {
        Instantiate(SusuPrefabs, new Vector3(transform.position.x, transform.position.y, transform.position.z+20f),Quaternion.identity);
    }

    void ShootingStar()
    {
        for (int i = 1; i < 6; i++)
        {
            Instantiate(ShootingStarPrefabs, new Vector3(transform.position.x+i*5, transform.position.y+20, transform.position.z + 20f), Quaternion.identity);
        }

    }

}
