using EnumTypes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CAnimationComponent : BaseComponent
{
    [SerializeField]
    Animator animator;


    //list는 각각의 ani열거형을 이용해서 접근
    public Dictionary<EnumTypes.eAnimationState, List<AnimationClip>> clips = new Dictionary<eAnimationState, List<AnimationClip>>();

    public Animation tempani;
    //테스트용
    public AnimationClip[] Attackclips;

    private void Awake()
    {
        for(EnumTypes.eAnimationState i = 0;i<EnumTypes.eAnimationState.AniStateMax;i++)
        {
            AnimationClip[] tempclips = Resources.LoadAll<AnimationClip>($"Clips.{i}");

            if(i==EnumTypes.eAnimationState.Attack)
            {
                Attackclips = tempclips;
            }
            clips.Add(i, tempclips.ToList());
        }


        InitComtype();
        animator = GetComponentInChildren<Animator>();
    }

    public override BaseComponent GetComponent()
    {
        return this;
    }

    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.AnimatorCom;
    }

    public void SetInt(string valname, int value)
    {
        animator.SetInteger(valname, value);
    }

    public void GetCurrentAnimatorStateInfo(int index)
    {
        animator.GetCurrentAnimatorStateInfo(index);
    }

    public void SetBool(EnumTypes.eAnimationState state, bool value)
    {
        animator.SetBool(state.ToString(), value);
        if(value)
        {
            value = value ? false : true;
            //상태는 한번에 한가지만 가능 (움직이는상태, 공격하는 상태, 피격당한 상태...)
            for (EnumTypes.eAnimationState a = 0; a < EnumTypes.eAnimationState.AniStateMax; a++)
            {
                if (a != state)
                {
                    animator.SetBool(a.ToString(), value);
                }
            }
        }
    }

    public bool GetBool(EnumTypes.eAnimationState state)
    {
        bool a = animator.GetBool(state.ToString());
        return animator.GetBool(state.ToString());
    }

    public void SetBool(string valname, bool value)
    {
        animator.SetBool(valname, value);
        
    }

    public void SetTrigger(string valname)
    {
        animator.SetTrigger(valname);
    }




}
