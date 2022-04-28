using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumTypes
{
    public enum eManagerTypes
    {
        InputManager,
        MoveManager,
        AnimationManager,


    }

    public enum eComponentTypes
    {
        InputCom,
        MoveCom,
        AnimatorCom,

        comMax
    }
    public enum eInputEvents
    {

    }

    public enum eAnimationClips
    {
        Idle01,
        Idle02,
        Idle03,
        Dash,
        Die,
        Attack01,
        Attack010,
        Attack02,
        Damage,
        Run,
        Skill01,
        Skill02,
        Skill03,
        Skill04,
        Stun,
        AnimationMax
    }

}
