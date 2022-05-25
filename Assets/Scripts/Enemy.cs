using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Info")]
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float Attack_Range; // 기본 공격 사거리
    [SerializeField]
    protected int Mana; // 현재 마나
    [SerializeField]
    protected int need_Mana; // 스킬 사용시 필요한 마나
    [Header("Enemy Now State")]
    [SerializeField]
    protected bool is_Target_Set; // 타겟이 범위내로 들어와서 정해져있다면
    [SerializeField]
    protected Vector3 return_Pos; // 복귀할 위치
    [SerializeField]
    protected int cur_State; // 현재 상태 1 : 순찰 2 : 추적 3 : 공격 4 : 복귀
    [SerializeField]
    protected GameObject cur_Target;
    [SerializeField]
    protected int next_Skill;

    protected Animator anim;

    protected void parent_Init()
    {
        return_Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        destination_Pos = transform.position;
        anim = GetComponent<Animator>();
        cur_State = 1;
    }

    [SerializeField]
    protected Vector3 destination_Pos;
    protected bool patrol_Start = false; // 탐색 시작
    protected void Enemy_Patrol()
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

        Collider[] cols = Physics.OverlapSphere(transform.position, 10f);  //, 1 << 8); // 비트 연산자로 8번째 레이어

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Player")
                {
                    cur_Target = cols[i].gameObject;
                    cur_State = 2; // 추적 상태로 돌입
                }
            }
        }
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
                                                                 Time.deltaTime * moveSpeed);
       
        if (Vector3.Distance(transform.position, in_destination_Pos) <= 0.5f)
        {
            anim.SetBool("isWalk", false);
        }
        else
        {
            anim.SetBool("isWalk", true); 
            transform.LookAt(in_destination_Pos);
        }
    }

    protected void Enemy_Trace() // 추적 함수
    {
        if (Vector3.Distance(transform.position, cur_Target.transform.position) <= Attack_Range) // 타겟에 닿았다면
        {
            cur_State = 3; // 공격 상태로 변경
        }
        else
        {
            Destination_Move(cur_Target.transform.position);
        }
    }

    public void Enemy_Return_Set()
    {
        cur_State = 4;
    }

    protected void Enemy_Return()
    {
        if (Vector3.Distance(transform.position, return_Pos) == 0)
        {
            cur_State = 1; // 복귀 완료 후 다시 순찰시작
            StartCoroutine(patrol_Think_Coroutine());
            patrol_Start = true;
        }
        else
        {
            Destination_Move(return_Pos);
        }
    }

    abstract protected void Enemy_FSM();

    abstract protected void Enemy_Attack(); // 안에서 마나가 다찼으면 저장된 스킬을 발동.

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10f);
    }

    void Update()
    {

    }
}
