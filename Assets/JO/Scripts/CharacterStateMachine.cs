using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 캐릭터의 상태를 관리, 상태에 따른 동작(애니메이션)들을 해준다.
public class CharacterStateMachine : MonoBehaviour
{
    public enum E_CharacterState
    {
        Idle,
        Move,
        Attack,
        Jump,
        Slip,
        OutOfControl,

    }

    public E_CharacterState characterState;


    private void Update()
    {
        
    }
}
