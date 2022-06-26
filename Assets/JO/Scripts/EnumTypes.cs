using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumTypes
{
    public enum eComponentTypes
    {
        InputCom,
        MoveCom,
        AnimatorCom,
        GuardCom,
        AttackCom,
        comMax
    }
    public enum eInputEvents
    {

    }

    public enum eAnimationState
    {
        Idle,
        Attack,
        Skill,
        Die,
        Stun,
        Damage,
        Move,
        AniStateMax
    }

    public enum eAniMove
    {
        Run,
        Dash,
        MoveMax
    }


    public enum eAniIdle
    {
        Idle01,
        Idle02,
        Idle03,
        IdleMax
    }

    public enum eAniSkill
    {
        Skill01,
        Skill02,
        Skill03,
        Skill04,
        SkillMax
    }

    public enum eAniAttack
    {
        Attack01,
        Attack02,
        AttackMax
    }

    //public enum eAnimationClips
    //{
    //    Idle01,
    //    Idle02,
    //    Idle03,
    //    Dash,
    //    Die,
    //    Attack01,
    //    Attack010,
    //    Attack02,
    //    Damage,
    //    Run,
    //    Skill01,
    //    Skill02,
    //    Skill03,
    //    Skill04,
    //    Stun,
    //    AnimationMax
    //}

}
