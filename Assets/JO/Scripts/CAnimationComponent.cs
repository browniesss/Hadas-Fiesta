using EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationComponent : BaseComponent
{
    [SerializeField]
    Animator animator;

   
    public AnimationClip[][] clips;
    public Animation tempani;
    public AnimationClip[] Attackclips;

    private void Awake()
    {
        clips = new AnimationClip[(int)EnumTypes.eAnimationState.AniStateMax][];

        for(int i=0;i<clips.GetLength(0);i++)
        {

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
