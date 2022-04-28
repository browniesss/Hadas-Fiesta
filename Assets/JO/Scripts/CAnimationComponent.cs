using EnumTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationComponent : BaseComponent
{
    [SerializeField]
    Animator animator;

    private void Awake()
    {
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

    public void SetBool(string valname, bool value)
    {
        animator.SetBool(valname, value);
    }

    public void SetTrigger(string valname)
    {
        animator.SetTrigger(valname);
    }




}
