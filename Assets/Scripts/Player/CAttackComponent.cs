using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jo
public class CAttackComponent : BaseComponent
{
    [SerializeField]
    CurState curval;

    public float LastAttackTime;

    public int AttackNum = 0;
    public CMoveComponent movecom;

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

        public float EffectStartTime;

        public GameObject Effect;

        public Transform EffectPosRot;

        public float movedis;

        public float movetime;
    }

    //스킬도 여기서 한번에 처리
    [System.Serializable]
    public class SkillInfo
    {
        public string SkillName;

        public int SkillNum;

        public AnimationClip aniclip;

        public float animationPlaySpeed;

        public float MovementDelay;

        public float NextMovementTimeVal;

        public float damage;

        public GameObject Effect;

        public float EffectStartTime;

        public Transform EffectPosRot;

        public float Movedis;

        public float MoveTime;

    }


    public AnimationController animator;

    public AnimationEventSystem eventsystem;

    public AttackMovementInfo[] attackinfos;

    public SkillInfo[] skillinfos;

    public GameObject effectobj;

    public Transform preparent;

    public float lastAttackTime = 0;

    public delegate void Invoker();

    

    void Start()
    {
        //animator = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;
        
        animator = GetComponentInChildren<AnimationController>();
        eventsystem = GetComponentInChildren<AnimationEventSystem>();

        for(int i=0;i<attackinfos.Length;i++)
        {
            eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null), 
                new KeyValuePair<string, AnimationEventSystem.midCallback>(attackinfos[i].aniclip.name,AttackMove), 
                new KeyValuePair<string, AnimationEventSystem.endCallback > (attackinfos[i].aniclip.name, AttackEnd));
        }
        for(int i=0;i<skillinfos.Length;i++)
        {
            eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
                new KeyValuePair<string, AnimationEventSystem.midCallback>(skillinfos[i].aniclip.name, AttackMove),
                new KeyValuePair<string, AnimationEventSystem.endCallback>(skillinfos[i].aniclip.name, AttackEnd));
        }
        //eventsystem.AddEvent(null, new KeyValuePair<string, AnimationEventSystem.midCallback>() AttackMove, AttackEnd);


    }

    //공격이 시작된지 일정 시간 뒤에 이펙트를 실행해야 할 때 사용
    IEnumerator Cor_TimeCounter(float time, Invoker invoker)
    {
        float starttime = Time.time;

        while(true)
        {
            if((Time.time - starttime)>=time)
            {
                invoker.Invoke();
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //스킬을 재생해준다.
    public void SkillAttack(int skillnum)
    {
        if (skillnum < 0 || skillnum > skillinfos.Length)
            return;

        if (movecom == null)
        {
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            curval = movecom.curval;
        }

        if (curval.IsAttacking)
            return;

        if (curval.IsAttacking == false)
            curval.IsAttacking = true;

        //StartCoroutine(Cor_TimeCounter(skillinfos[skillnum].EffectStartTime, CreateEffect));
        animator.Play(skillinfos[skillnum].aniclip.name, skillinfos[skillnum].animationPlaySpeed);
    }


    public void Attack()
    {
        if(movecom==null)
        {
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            curval = movecom.curval;
        }

        if (curval.IsAttacking)
            return;

        if (curval.IsAttacking == false)
            curval.IsAttacking = true;

        //Debug.Log("공격 들어옴");
        float tempval = Time.time - lastAttackTime;
        //Debug.Log($"경과된 시간{tempval}, 연결시간{attackinfos[AttackNum].NextMovementTimeVal}");

        if (tempval <= attackinfos[AttackNum].NextMovementTimeVal)
        {
            AttackNum = (AttackNum + 1) % (int)EnumTypes.eAniAttack.AttackMax;

        }
        else
        {
            AttackNum = 0;
        }

        StartCoroutine(Cor_TimeCounter(attackinfos[AttackNum].EffectStartTime, CreateEffect));

        //Debug.Log($"{attackinfos[AttackNum].aniclip.name}애니메이션 {attackinfos[AttackNum].animationPlaySpeed}속도록 실핼");
        animator.Play(attackinfos[AttackNum].aniclip.name, attackinfos[AttackNum].animationPlaySpeed);

        

    }

    public void AttackMove(string clipname)
    {
        for(int i=0;i<attackinfos.Length;i++)
        {
            if(attackinfos[i].aniclip.name == clipname)
            {
                //movecom.FowardDoMove(5, animator.GetClipLength(attackinfos[AttackNum].aniclip.name) / 2);
                movecom.FowardDoMove(attackinfos[i].movedis, attackinfos[i].movetime);

                return;
            }
        }

        for(int i=0;i<skillinfos.Length;i++)
        {
            if(skillinfos[i].aniclip.name == clipname)
            {
                movecom.FowardDoMove(skillinfos[i].Movedis, skillinfos[i].MoveTime);
                return;
            }
        }

    }

    //공격 이펙트를 생성
    public void CreateEffect()
    {
        effectobj = GameObject.Instantiate(attackinfos[AttackNum].Effect);
        effectobj.transform.position = attackinfos[AttackNum].EffectPosRot.position;
        effectobj.transform.rotation = attackinfos[AttackNum].EffectPosRot.rotation;

        preparent = effectobj.transform.parent;
        effectobj.transform.parent = attackinfos[AttackNum].EffectPosRot;
        //copyobj.transform.TransformDirection(movecom.com.FpRoot.forward);


        Destroy(effectobj, 1.5f);
        //effectobj = null;
    }



    //공격애니메이션이 끝나면 해당 함수가 들어온다
    public void AttackEnd(string s_val)
    {
        

        if(effectobj!=null)
        {
            Debug.Log($"공격 끝 들어옴 -> {s_val}");
            effectobj.transform.parent = preparent;
        }

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
