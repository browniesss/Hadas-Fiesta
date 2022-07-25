using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGuardComponent : BaseComponent
{
    public CMoveComponent movecom;
    public AnimationController animator;
    public AnimationEventSystem eventsystem;
    //public IEnumerator coroutine;


    [Header("============Guard Options============")]
    public float GuardTime;//최대로 가드를 할 수 있는 시간
    public float GuardStunTime;//가드 경직 시간
    public int MaxGuardGauge;//
    public int BalanceDecreaseVal;
    public AnimationClip GuardStunClip;
    public AnimationClip GuardClip;

    [Header("============Cur Values============")]
    public int CurGuardGauge;
    public bool nowGuard;
    public float GaugeDownInterval;
    //public bool playingCor;
    public IEnumerator guardcoroutine;
    public IEnumerator stuncoroutine;
    public delegate void Invoker();

    public void Guard()
    {
        if (movecom == null)
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;

        if (movecom.curval.IsGuard)
            return;

        movecom.curval.IsGuard = true;

        movecom.com.animator.Play(GuardClip.name, 2.0f);

        if (guardcoroutine != null)
        {
            //playingCor = false;
            //Debug.Log("실행중 나감");
            StopCoroutine("Cor_TimeCounter");
            guardcoroutine = null;

        }
        guardcoroutine = Cor_TimeCounter(GuardTime, GuardDown);
        StartCoroutine(guardcoroutine);
    }

    //
    public void GuardDown()
    {
        if (!movecom.curval.IsGuard)
            return;

        if (guardcoroutine != null)
        {
            //playingCor = false;
            //Debug.Log("실행중 나감");
            StopCoroutine(guardcoroutine);
            if(stuncoroutine!=null)
            {
                StopCoroutine(stuncoroutine);
                stuncoroutine = null;
            }
            guardcoroutine = null;
        }
            

        movecom.curval.IsGuard = false;
        //CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
    }

    //공격이 시작된지 일정 시간 뒤에 이펙트를 실행해야 할 때 사용
    IEnumerator Cor_TimeCounter(float time, Invoker invoker)
    {
        //playingCor = true;
        float starttime = Time.time;
        //Debug.Log("다시시작");
        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                //Debug.Log("시간다됨");
                invoker.Invoke();
                //guardcoroutine = null;
                //playingCor = false;
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


    //가드중일때 데미지가 들어왔을때는 이쪽으로 들어온다.
    public void Damaged_Guard(float damage)
    {
        if (PlayableCharacter.Instance.status.CurBalance >= BalanceDecreaseVal)
        {
            PlayableCharacter.Instance.status.CurBalance -= BalanceDecreaseVal;
            GuardStun();
        }
        else
        {
            PlayableCharacter.Instance.Damaged(damage);
        }
    }


    //가드넉백상태는 outofcontrol 상태로 넘어가지 않고 가드중인 상태인 것으로 한다.
    public void GuardStun()
    {
        CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.GuardStun);
        animator.Play(GuardStunClip.name,2.8f);
        stuncoroutine = Cor_TimeCounter(GuardStunTime, StunEnd);
        StartCoroutine(stuncoroutine);
        // Cor_TimeCounter
    }

    public void StunEnd()
    {
        Debug.Log("스턴끝 들어옴");
        CharacterStateMachine.eCharacterState prestate = CharacterStateMachine.Instance.GetPreState();
        CharacterStateMachine.Instance.SetState(prestate);
        //if(prestate == CharacterStateMachine.eCharacterState.Guard)
        //{
        //    movecom.com.animator.Play(GuardClip.name, 2.0f);
        //}
        stuncoroutine = null; 
    }

    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.GuardCom;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<AnimationController>();
        eventsystem = GetComponentInChildren<AnimationEventSystem>();
        //eventsystem.AddEvent(new KeyValuePair<string, AnimationEventSystem.beginCallback>(null, null),
        //        new KeyValuePair<string, AnimationEventSystem.midCallback>(null, null),
        //        new KeyValuePair<string, AnimationEventSystem.endCallback>(GuardStunClip.name, AttackEnd));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
