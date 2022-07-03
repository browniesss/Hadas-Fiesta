using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackComponent : BaseComponent
{
    //public AnimationClip[] Attack
    [SerializeField]
    private int AttackCount;

    CurState curval;

    [Range(0.0f,5.0f)]
    [Tooltip("공격 모션이 끝나고 해당 시간 안에 공격버튼을 클릭해야지 연결동작이 진행")]
    public float LinkAttackInterval;

    public float LastAttackTime;

    //public bool NowAttack;

    //
    public bool Linkable;

    public int AttackNum = 0;
    public CMoveComponent movecom;

    public AnimationController animator;
    //public CAnimationComponent animator;

    [System.Serializable]
    public class AttackMovementInfo
    {
        public int AttackNum;

        //애니메이션 배속
        public float animationPlaySpeed;
        
        //해당 매니메이션 클립
        public AnimationClip aniclip;

        //후딜레이
        public float MovementDelay;

        //다음동작으로 넘어가기 위한 시간
        //해당동작이 끝나고 해당 시간 안에 Attack()함수가 호출되어야지 다음동작으로 넘어간다.
        public float NextMovementTimeVal;

        public float damage;
    }

    


    public AttackMovementInfo[] attckinfos;

    void Start()
    {
        //animator = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;
        movecom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
        //curval = movecom.curval;



    }


    //공격 중에는 1프레임 마다 반복문을 돌면서 공격을 받는등의 상태 변화가 생기진 않았는지 확인한다.
    IEnumerator Cor_AttackTimeCounter()
    {
        Linkable = true;

        while(true)
        {
            //if()


        }

        yield return new WaitForSeconds(LinkAttackInterval);
        Linkable = false;
    }

    public void Attack()
    {
        if (curval.IsAttacking)
            return;


        if (Linkable)
        {
            AttackCount = (AttackCount + 1) % (int)EnumTypes.eAniAttack.AttackMax;

        }
        else
        {
            AttackCount = 0;
        }


        curval.IsAttacking = true;
    }

    //공격애니메이션이 끝나면 해당 함수가 들어온다
    public void AttackEnd(int num)
    {
        Debug.Log($"공격 끝 들어옴{num}");
        //animator.SetBool(EnumTypes.eAnimationState.Attack, false);
        //animator.SetBool(EnumTypes.eAnimationState.Idle, true);
        //LastAttackTime = Time.time;
        ////NowAttack = false;
        //StartCoroutine(Cor_AttackTimeCounter());
        
    }

    //공격이 중간에 끊겨야 할때
    public void AttackCutOff()
    {

    }



    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.AttackCom;
    }

}
