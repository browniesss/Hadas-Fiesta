using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ex ) 원거리, 근거리 처럼 다른 스테이트 프로세스를 수행해야 한다면 
스테이트 처리기를 상속받은 클래스를 구현해서, 예를들어서 patrol 이 필요없는 ai 종류의 스테이트 처리기, 필요한 종료의 스테이트 처리기 등을
구현해야함 . 그리고 state_handler 를 상속이 아니라 ai 처럼 가지고 있을 수 있게 해야함. 

시간 값 저장해주는 것도 처리.
 */

public class Battle_Character : MonoBehaviour
{
    [SerializeField]
    protected FSM_AI ai = new FSM_AI();

    [SerializeField]
    protected State_Handler state_handler;

    // 스테이트 처리기를 생성. 캐릭터에 따라서 다른 스테이트 처리기를 받아옴. 
    public GameObject cur_Target;
    [SerializeField]
    public Vector3 return_Pos; // 복귀할 위치
    public Vector3 destination_Pos; // Patrol 목적지
    public float Attack_Range; // 사거리
    public bool patrol_Start = false; // 탐색 시작
    public int Mana; // 몬스터 마나
    public int need_Mana; // 스킬 사용시 필요한 마나
    public int next_Skill;
    public int Max_HP; // 최대 체력
    public int Cur_HP; // 현재 체력
    protected Animator anim;

    public void Stat_Initialize(MonsterInformation info)
    {
        //        st = ScriptableObject.CreateInstance<MonsterInformation>();

    }

    protected void Initalize()
    {

        return_Pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        destination_Pos = transform.position;

        // 여기서 switch 로 종류에 따라 스테이트 처리기 분리
        state_handler = new General_Monster_State();

        state_handler.State_Handler_Initialize(this);
        //anim = GetComponent<Animator>();
    }

    public virtual void Skill_1()
    {

    }

    public virtual void Skill_2()
    {

    }

    public virtual void Skill_3()
    {

    }
}
