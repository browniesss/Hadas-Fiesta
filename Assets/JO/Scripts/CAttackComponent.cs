using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackComponent : BaseComponent
{
    //public AnimationClip[] Attack
    [SerializeField]
    //private int AttackCount;

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

    //public AnimationController animator;
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

        public GameObject Effect;

        public Transform EffectPosRot;
    }

    public AnimationController animator;

    public AnimationEventSystem eventsystem;

    public AttackMovementInfo[] attackinfos;

    public float lastAttackTime = 0;

    void Start()
    {
        //animator = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;
        
        animator = GetComponentInChildren<AnimationController>();
        eventsystem = GetComponentInChildren<AnimationEventSystem>();
        eventsystem.AddEvent(null, null, AttackEnd);
        



    }


    //공격 중에는 1프레임 마다 반복문을 돌면서 공격을 받는등의 상태 변화가 생기진 않았는지 확인한다.
    IEnumerator Cor_AttackTimeCounter()
    {
        Linkable = true;
        float starttime;


        while(true)
        {
            //if()

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }




    public void Attack()
    {
        if(movecom==null)
        {
            movecom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            curval = movecom.curval;
        }

        if (curval.IsAttacking)
            return;

        if (curval.IsAttacking == false)
            curval.IsAttacking = true;

        Debug.Log("공격 들어옴");
        float tempval = Time.time - lastAttackTime;
        Debug.Log($"경과된 시간{tempval}, 연결시간{attackinfos[AttackNum].NextMovementTimeVal}");

        if (tempval <= attackinfos[AttackNum].NextMovementTimeVal)
        {
            AttackNum = (AttackNum + 1) % (int)EnumTypes.eAniAttack.AttackMax;

        }
        else
        {
            AttackNum = 0;
        }

        GameObject copyobj = GameObject.Instantiate(attackinfos[AttackNum].Effect);
        copyobj.transform.position = attackinfos[AttackNum].EffectPosRot.position;
        //copyobj.transform.rotation = attackinfos[AttackNum].EffectPosRot.rotation;
        copyobj.transform.LookAt(movecom.com.FpRoot.forward);
        Destroy(copyobj, 1.5f);

        Debug.Log($"{attackinfos[AttackNum].aniclip.name}애니메이션 {attackinfos[AttackNum].animationPlaySpeed}속도록 실핼");
        animator.Play(attackinfos[AttackNum].aniclip.name, attackinfos[AttackNum].animationPlaySpeed);

        //movecom.FowardDoMove(5, animator.GetClipLength(attackinfos[AttackNum].aniclip.name)/2);

    }




    //공격애니메이션이 끝나면 해당 함수가 들어온다
    public void AttackEnd(string s_val)
    {
        Debug.Log($"공격 끝 들어옴 -> {s_val}");
        if (curval.IsAttacking == true)
            curval.IsAttacking = false;

        lastAttackTime = Time.time;
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
