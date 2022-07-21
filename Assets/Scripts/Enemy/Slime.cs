using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Battle_Character
{
    public bool isDivide = false; // 한번밖에 분열하지 못하므로 분열을 이미 한 슬라임인지 체크하기 위함.

    public bool OnTree = true; // 나무 위에 있는지

    public bool isJump = false; // 점프 중인지 체크

    void Start()
    {
        Initalize();
        ai.AI_Initialize(this);
    }

    Vector3 dirvec;
    void Update()
    {
        state_handler.state = ai.AI_Update();
        state_handler.State_Handler_Update();

        if (cur_Target != null)
        {
            dirvec = cur_Target.transform.position - transform.position;
            dirvec += new Vector3(0, 8, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(dirvec * 200f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, mon_find_Range);
    }

    public override void Skill_1() // 슬라임 1번 스킬 ( 흡수 ) 
    {
        Debug.Log("흡수 발동");

        state_handler.navMesh.enabled = false;

        Vector3 dirvec = cur_Target.transform.position - transform.position;
        dirvec += new Vector3(0, 8, 0);

        GetComponent<Rigidbody>().AddForce(dirvec * 500f);

        ai.now_State = State.Next_Wait;

        Player_Mana = 0;

        StartCoroutine(Skill_Coroutine());
    }

    IEnumerator Skill_Coroutine()
    {
        yield return new WaitForSeconds(2f);

        state_handler.navMesh.enabled = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        ai.now_State = State.Patrol_Enter;
    }

    public override void Skill_2() // 분열 ( 죽으면 부활 )  
    {
        Debug.Log("분열 발동");
        // 슬라임 2마리 생성해줌
        // 생성한 슬라임 크기와 체력 감소 Slime_Devide_Init 함수 실행해주기 
    }

    public override void Die_Process() // 죽을때 호출되는 함수 (부활 처리해야함)
    {
        Skill_2();
    }

    public void Slime_Devide_Init(Slime slime)
    {
        slime.isDivide = true;

        slime.transform.localScale *= 0.5f;

        slime.Max_HP = slime.Max_HP * 0.5f;

        slime.Cur_HP = slime.Max_HP;
    }
}
