using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{

    public GameObject SusuPrefabs;
    public GameObject ShootingStarPrefabs;

    bool check_skill=false;
    int skill_coolingTime = 0;  //스킬 쿨타임 설정

    bool isDelay = true;
    float delayTime = 1f;
    float timer = 0f;

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

    IEnumerator Susu_Skill_Check()
    {
        check_skill = true;
        yield return new WaitForSeconds(10f);
        check_skill = false;
    }

    protected override void Enemy_Attack()
    {
        if (Mana >= need_Mana)
        {
            next_Skill = Random.Range(1, 3);
            switch (next_Skill)
            {
                case 1: // 1번 스킬
                    if (!check_skill)
                    {
                        susu_Summons();
                        StartCoroutine(Susu_Skill_Check());
                    }
                    else
                    {
                        next_Skill = 2;
                    }
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

        if (isDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0f;
                Mana += 5;
            }
        }

    }


    void susu_Summons()
    {
        if(cur_Target!=null)
        {
            float distance = Vector3.Distance(cur_Target.transform.position, transform.position);
            Vector3 dir = cur_Target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir= dir.normalized;


         
            Vector3 right_pos = Quaternion.AngleAxis(30, Vector3.up) * dir;
            Vector3 left_pos = Quaternion.AngleAxis(-30, Vector3.up) * dir;

           
            Quaternion lookRotation1 = Quaternion.LookRotation(right_pos);
            Quaternion lookRotation2 = Quaternion.LookRotation(left_pos);


            float speed = 2.0f;
           // pos = pos - transform.position;

           
            GameObject tmep = Instantiate(SusuPrefabs, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            tmep.transform.position += right_pos * (distance*0.5f);
            dir = (cur_Target.transform.position - tmep.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            tmep.transform.rotation = lookRotation;

            GameObject tmep1 = Instantiate(SusuPrefabs, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            tmep1.transform.position += left_pos * (distance * 0.5f);
            dir = (cur_Target.transform.position - tmep1.transform.position).normalized;
           lookRotation = Quaternion.LookRotation(dir);
            tmep1.transform.rotation = lookRotation;

            //GameObject tmep1 = Instantiate(SusuPrefabs, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //tmep.transform.rotation = lookRotation;
            //tmep.transform.position += (dir*0.5f);

            // Instantiate(SusuPrefabs, new Vector3(transform.position.x, transform.position.y, transform.position.z* distance), Quaternion.identity);

            //캐릭터 ㅏ라보기
            //SusuPrefabs.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }
    }

    void ShootingStar()
    {
        if (cur_Target != null)
        {
            for (int i = -2; i < 3; i++)
            {
                GameObject temp= Instantiate(ShootingStarPrefabs, new Vector3(transform.position.x + i * 5, transform.position.y + 20, transform.position.z), Quaternion.identity);
                temp.GetComponent<Shooting>().eixst = true;

                temp.GetComponent<Shooting>().Shooting_target(cur_Target.transform.position);
          
                    // Vector3 dir = (cur_Target.transform.position - temp.transform.position).normalized;
                //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //temp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

               // temp.GetComponent<Rigidbody>().useGravity = false;
               //temp.GetComponent<Rigidbody>().AddForce(dir * 100);

            }
        }
      
    }

}
