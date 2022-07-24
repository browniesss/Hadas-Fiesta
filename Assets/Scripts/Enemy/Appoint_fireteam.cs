using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appoint_fireteam : Enemy
{
    public int general_attack_damage;  //일반공격 데미지

   private float rush_speed=1000f;

    bool isDelay = true;
    float delayTime = 1f;
    float timer = 0f;


    void Start()
    {
        parent_Init();
    }


    void Update()
    {
        Enemy_FSM();

        if (isDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0f;
                Mana += 10;
            }
        }
    }

    void general_attack() //일반공격
    {
        //넉백
        //데미지
        //넉백 캐릭터 합치고 ㄱㄱ
        //데미지 얼마임?
        //데미지 캐릭터 hp에서 까야해서 캐릭 합치고 ㄱㄱ

        Debug.Log("일반공격");
    }

    private void FixedUpdate()
    {
        Vector3 dir;

        if(cur_State==5)
        {
            dir = (cur_Target.transform.position - transform.position).normalized;
            Debug.Log("대쉬");
            GetComponent<Rigidbody>().AddForce(dir * rush_speed);
        }
      
    }

    IEnumerator attack()
    {
        anim.SetBool("Melee Attack 02", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("Shockwave Attack", true);
        cur_State = 3;
    }

    void Rush_pierce()  //돌진찌르기
    {
        //앞으로 돌진후 데미지
        //데미지 얼마?
        //캐릭터 데미지 합치고 ㄱ
        anim.SetBool("isAttack", false);
        anim.SetTrigger("isWalk");

        Vector3 dir = (cur_Target.transform.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, cur_Target.transform.position) <= 1.5f)
        {
            anim.SetBool("isWalk", false);
            anim.SetTrigger("isAttack");
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("이제 멈춰");
            next_Skill = 0;
            cur_State = 6;


            //2연타
            //anim.SetBool("isAttack", false);
            //anim.SetBool("MeleeAttack02", true);
        }

        Debug.Log("2연타 멈춰");
        
        StartCoroutine(attack());

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
            case 5:

                if(next_Skill!=0)
                {
                    Rush_pierce();
                }

                break;
            case 6:
               // anim.SetBool("Melee Attack 02", true);
                break;

        }
    }

    protected override void Enemy_Attack()
    {
        if (Mana >= need_Mana)
        {
            if(next_Skill==0)
            {
                next_Skill = Random.Range(1, 3);
            }
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    cur_State = 5;
                  //  next_Skill = 0;
                    break;
                case 2: // 2번 스킬
                    general_attack();
                    next_Skill = 0;

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


   
}
