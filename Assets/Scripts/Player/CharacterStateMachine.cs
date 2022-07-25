using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jo
//현재 캐릭터의 상태를 관리
//
public class CharacterStateMachine : MySingleton<CharacterStateMachine>
{
    public enum eCharacterState
    {
        //Idle,//movecom
        //Walk,//movecom
        //Run,//movecom
        //Attack01,//attackcom 에서 애니메이션 관리
        //Attack02,//attackcom 
        //Attack03,//attackcom
        //Rolling,//movecom
        //Guard,//guardcom 에서 애니메이션 관리
        //GuardStun,//battlesystem 각각의 컴포넌트 들에서 애니메이션 관리
        //DamagedStun,//movecom 각각의 컴포넌트들에서 애니메이션 관리
        //DamagedKnockBack,//movecom 각각의 컴포넌트들에서 애니메이션 관리
        //Slip,//movecom 각각의 컴포넌트들에서 애니메이션 관리
        //OutOfControl,//move, battelsys, guard 

        Idle,
        Move,
        Attack,
        Rolling,
        Guard,
        OutOfControl,




        StateMax
    }

    [System.Serializable]
    public class AnimationBlendingTimeSet
    {
        public eCharacterState prestate;
        public eCharacterState changestate;
        [Range(0.0f, 5.0f)]
        public float blendtime;
        
    }

    //모션의 딜레이는 각각의 모션이 종료할때 각자가 가지고 있도록 한다.

    public List<AnimationBlendingTimeSet> animationBlendingTimeSets = new List<AnimationBlendingTimeSet>();
    //curstate
    public eCharacterState CurState;
    //
    public eCharacterState PreState;

    //상태 변화에 따라 애니메이션을 바꿔준다.
    public void SetState(eCharacterState state)
    {
        if (CurState != state)
        {
            //Debug.Log($"{state} 들어옴");
            PreState = CurState;
            CurState = state;
        }
    }

    public eCharacterState GetState()
    {
        return CurState;
    }

    public eCharacterState GetPreState()
    {
        return PreState;
    }

    private void Update()
    {
        
    }
}
