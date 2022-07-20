using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Knight : Battle_Character
{
    [SerializeField]
    private GameObject spawn_Skeleton_Prefab; // 소환할 스켈레톤 몬스터 프리팹

    [SerializeField]
    private bool isPassive = false; // 패시브 스킬 ( 스킬 3번 ) 이 발동되었는지 체크할 bool 변수

    // 방패를 들고 이동하고 방패를 들어올린 쪽에서 입는 데미지는 감소하기 때문에 콜라이더를 하나 더 만들어줘야함.
    void Start()
    {
        Initalize();
        ai.AI_Initialize(this);
    }

    void Update()
    {
        state_handler.state = ai.AI_Update();
        state_handler.State_Handler_Update();

        if (Input.GetKeyDown(KeyCode.Space))
            Damaged(5);
    }

    public override void Skill_1() // 스켈레톤 나이트 1번스킬 
    {
        Debug.Log("강타 발동");
        // 전방을 칼로 힘껏 치는 애니메이션
    }

    public override void Skill_2() // 스켈레톤 나이트 2번스킬 
    {
        Debug.Log("방패카운터 발동");
        // 전방을 방패로 힘껏 밀어 올려치는 애니메이션
    }

    public override void Skill_3()  // 스켈레톤 나이트 3번스킬 ( 패시브 스킬 : 체력 50 % 미만이 되면 발동 ) 
    {
        Debug.Log("포효 발동");
        // 칼로 방패를 2번 친 후 양팔을 벌린 채 포효를 내지르는 애니메이션.

        // 몬스터 8마리 소환
        // 소환되는 몬스터의 땅속에서 올라오는 애니메이션 실행
        for (int i = 0; i < 8; i++)
        {
            GameObject spawned_enemy = GameObject.Instantiate(spawn_Skeleton_Prefab);
            spawned_enemy.gameObject.name = i.ToString() + "번째";

            Vector3 v = new Vector3(Mathf.Sin(30.0f * i) * 5.0f, 0, Mathf.Cos(30.0f * i) * 5.0f);

            spawned_enemy.transform.position = transform.position + v;
        }
    }

    public override void Damaged(float damage_Amount)
    {
        base.Damaged(damage_Amount);

        Debug.Log("나데미지");

        if (Cur_HP <= (Max_HP / 2) && !isPassive)
        {
            isPassive = true;
            Skill_3();
        }
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
                case 2: // 2번 스킬
                    Skill_2();
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
