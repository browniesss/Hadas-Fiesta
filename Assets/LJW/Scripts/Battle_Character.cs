using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ex ) 원거리, 근거리 처럼 다른 스테이트 프로세스를 수행해야 한다면 
스테이트 처리기를 상속받은 클래스를 구현해서, 예를들어서 patrol 이 필요없는 ai 종류의 스테이트 처리기, 필요한 종료의 스테이트 처리기 등을
구현해야함 . 그리고 state_handler 를 상속이 아니라 ai 처럼 가지고 있을 수 있게 해야함.
 */

public class Battle_Character : State_Handler
{
    [SerializeField]
    protected FSM_AI ai = new FSM_AI();
    
    // 스테이트 처리기를 생성. 캐릭터에 따라서 다른 스테이트 처리기를 받아옴. 
    public GameObject cur_Target;
    [SerializeField]
    protected Vector3 return_Pos; // 복귀할 위치
    protected Vector3 destination_Pos; // Patrol 목적지
    public float Attack_Range; // 사거리
    protected bool patrol_Start = false; // 탐색 시작
    protected Animator anim;

    protected void Initalize()
    {
        return_Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        destination_Pos = transform.position;
        //anim = GetComponent<Animator>();
    }

    protected override void Patrol_Enter_Process()
    {
        patrol_Start = false;
    }

    protected override void Patrol_Process()
    {
        if (Vector3.Distance(transform.position, destination_Pos) == 0f)
        {
            if (!patrol_Start)
            {
                StartCoroutine(patrol_Think_Coroutine());
                patrol_Start = true;
            }
        }
        else
        {
            Destination_Move(destination_Pos);
        }
    }

    protected override void Trace_Process()
    {
        Destination_Move(cur_Target.transform.position);
    }

    protected override void Attack_Process()
    {

    }

    IEnumerator patrol_Think_Coroutine()  // 다음 목적지 생각하는 코루틴
    {
        yield return new WaitForSeconds(1f);

        int randX = Random.Range(-10, 10);
        int randZ = Random.Range(-10, 10);

        destination_Pos = new Vector3(return_Pos.x + randX, return_Pos.y, return_Pos.z + randZ);

        patrol_Start = false;
    }

    void Destination_Move(Vector3 in_destination_Pos)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                                 in_destination_Pos,
                                                                 Time.deltaTime * 5f);

        if (Vector3.Distance(transform.position, in_destination_Pos) <= 0.5f)
        {
            //if (cur_State == 4)
            //    anim.SetBool("isReturn", false);
            //else
            //  anim.SetBool("isWalk", false);
        }
        else
        {
            //if (cur_State == 4)
            //    anim.SetBool("isReturn", true);
            //else
            //    anim.SetBool("isWalk", true);

            transform.LookAt(in_destination_Pos);
        }
    }
}
