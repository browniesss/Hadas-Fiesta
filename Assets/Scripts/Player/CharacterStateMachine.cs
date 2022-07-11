using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jo
//현재 캐릭터의 상태를 관리, 상태에 따른 동작(애니메이션)들을 해준다.
//
public class CharacterStateMachine : MonoBehaviour
{
    [System.Serializable]
    public class AnimationBlendingTimeSet
    {
        public EnumTypes.eCharacterState prestate;
        public EnumTypes.eCharacterState changestate;
        [Range(0.0f, 5.0f)]
        public float blendtime;
        
    }

    //모션의 딜레이는 각각의 모션이 종료할때 각자가 가지고 있도록 한다.

    public List<AnimationBlendingTimeSet> animationBlendingTimeSets = new List<AnimationBlendingTimeSet>();
    //curstate
    public EnumTypes.eCharacterState CurState;
    //
    public EnumTypes.eCharacterState PreState;

    //상태 변화에 따라 애니메이션을 바꿔준다.
    public void SetState(EnumTypes.eCharacterState state)
    {
        PreState = CurState;
        CurState = state;

        //switch(CurState)
        //{
        //    //달리기->기본, 공격1타->기본, 공격2타->기본, 공격3타->기본, 걷기->기본, 구르기->기본
        //    case E_CharacterState.Idle:

        //        break;
            
        //    case E_CharacterState.Rolling:

        //        break;
        //    case E_CharacterState.Guard:

        //        break;
        //    case E_CharacterState.Slip:

        //        break;
        //    case E_CharacterState.OutOfControl:

        //        break;
        //}



    }

    public EnumTypes.eCharacterState GetState()
    {
        return CurState;
    }

    public EnumTypes.eCharacterState GetPreState()
    {
        return PreState;
    }

    private void Update()
    {
        
    }
}
