using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jo
public class testAttack123 : BaseComponent
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

    [SerializeField]
    public List<PlayerAttack_Information> Attack_InformationList = new List<PlayerAttack_Information>();

    [SerializeField]
    public PlayerAttack_Information SkillData;

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

    [SerializeField]
    public Collider[] colliders;

    public AnimationController animator;

    public AnimationEventSystem eventsystem;

    public AttackMovementInfo[] attackinfos;

    public SkillInfo[] skillinfos;

    public GameObject effectobj;

    public Transform preparent;

    public float lastAttackTime = 0;

    public delegate void Invoker();

    public AttackManager testAttckmanager;

    public Transform AttackColliderParent;

    void Start()
    {
        colliders = GetComponentsInChildren<Collider>();

        //for(int i=0;i<2;i++)
        //{
        //    if(colliders[i].name == StaticClass.PlayerAttackCollider)
        //    {
        //        colliders[i].
        //    }
        //}


        for (int i = 0; i < Attack_InformationList.Count; i++)
        {
            Debug.Log(Attack_InformationList[i].P_AttackNum);
        }

        animator = GetComponentInChildren<AnimationController>();
        eventsystem = GetComponentInChildren<AnimationEventSystem>();

        for (int i = 0; i < attackinfos.Length; i++)
        {
            eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
                new KeyValuePair<string, AnimationEventSystem.midCallback>(attackinfos[i].aniclip.name, AttackMove),
                new KeyValuePair<string, AnimationEventSystem.endCallback>(attackinfos[i].aniclip.name, AttackEnd));
        }
        for (int i = 0; i < skillinfos.Length; i++)
        {
            eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
                new KeyValuePair<string, AnimationEventSystem.midCallback>(skillinfos[i].aniclip.name, AttackMove),
                new KeyValuePair<string, AnimationEventSystem.endCallback>(skillinfos[i].aniclip.name, AttackEnd));
        }

        

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            return;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SkillAttack();
            return;
        }
    }

    //공격이 시작된지 일정 시간 뒤에 이펙트를 실행해야 할 때 사용
    IEnumerator Cor_TimeCounter(float time, Invoker invoker)
    {
        float starttime = Time.time;

        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke();
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //스킬을 재생해준다.
    public void SkillAttack()
    {      
        if (movecom == null)
        {
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            //testAttckmanager.AddComponent(movecom);
            curval = movecom.curval;
        }

        if (curval.IsAttacking)
            return;

        if (curval.IsAttacking == false)
            curval.IsAttacking = true;


        testAttckmanager.AttackMana(animator, SkillData.P_aniclip.name, SkillData.P_animationPlaySpeed);
    }

    public void CreateEffect()
    {
        testAttckmanager.CreateEffect(Attack_InformationList[AttackNum].P_Effect, attackinfos[AttackNum].EffectPosRot, 1.5f);
        //preparent = testAttckmanager.CreateEffect(Attack_InformationList[AttackNum].P_Effect, attackinfos[AttackNum].EffectPosRot, 1.5f);
        //preparent = testAttckmanager.CreateEffect(Attack_InformationList[AttackNum].P_Effect, Attack_InformationList[AttackNum].P_EffectPosRot, 1.5f);
    }

    public void Attack()
    {
        if (curval.IsAttacking)
            return;

        if (movecom == null)
        {
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            //testAttckmanager.AddComponent(movecom);
            curval = movecom.curval;
        }

        if (curval.IsAttacking == false)
            curval.IsAttacking = true;
        
        float tempval = Time.time - lastAttackTime;
        
        if (tempval <= Attack_InformationList[AttackNum].P_NextMovementTimeVal)
        {
            AttackNum = (AttackNum + 1) % (int)EnumTypes.eAniAttack.AttackMax;

        }
        else
        {
            AttackNum = 0;
        }

        StartCoroutine(Cor_TimeCounter(Attack_InformationList[AttackNum].P_EffectStartTime, CreateEffect));

        testAttckmanager.ComboAttackMana(animator, Attack_InformationList[AttackNum].P_aniclip.name, Attack_InformationList[AttackNum].P_animationPlaySpeed);

        

    }

    public void AttackMove(string clipname)
    {
       
        for (int i = 0; i < attackinfos.Length; i++)
        {
            if (attackinfos[i].aniclip.name == clipname)
            {               
                movecom.FowardDoMove(Attack_InformationList[i].P_movedis, Attack_InformationList[i].P_movetime);

                return;
            }
        }

        for (int i = 0; i < skillinfos.Length; i++)
        {
            if (skillinfos[i].aniclip.name == clipname)
            {
                movecom.FowardDoMove(skillinfos[i].Movedis, skillinfos[i].MoveTime);
                return;
            }
        }

    }

   
   
    public void AttackEnd(string s_val)
    {
        if (effectobj != null)
        {
            Debug.Log($"dasdw공격 끝 들어옴 -> {s_val}");
            effectobj.transform.parent = preparent;
        }
        

        if (curval.IsAttacking == true)
            curval.IsAttacking = false;

        lastAttackTime = Time.time;


        
    }

   
    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.AttackCom;
    }

}

