using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어블 캐릭터의 모든것을 관리한다.
//1. 컴포넌트들 관리 기존 ComponentManager가 하던 일을 그대로 실행
//2. 
public class PlayableCharacter : BaseStatus
{
    //싱글톤
    static PlayableCharacter _instance;
    public static PlayableCharacter Instance
    {
        get
        {
            return _instance;
        }
    }

    [Header("================UnityComponent================")]
    public CharacterStateMachine statemachine;


    [Header("================BaseComponent================")]
    public BaseComponent[] components = new BaseComponent[(int)EnumTypes.eComponentTypes.comMax];


    private void Awake()
    {
        _instance = this;

        BaseComponent[] temp = GetComponentsInChildren<BaseComponent>();

        foreach (BaseComponent a in temp)
        {
            components[(int)a.p_comtype] = a;
        }
    }
    public BaseComponent GetMyComponent(EnumTypes.eComponentTypes type)
    {
        return components[(int)type];
    }

    public void InActiveMyComponent(EnumTypes.eComponentTypes type)
    {
        components[(int)type].enabled = false;
    }

    public void ActiveMyComponent(EnumTypes.eComponentTypes type)
    {
        components[(int)type].enabled = true;
    }



    private void Update()
    {
        
    }


}
