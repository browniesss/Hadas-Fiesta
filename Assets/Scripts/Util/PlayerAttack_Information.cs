using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttack Data", menuName = "Scriptable Object/PlayerAttack Data", order = int.MaxValue)]

public class PlayerAttack_Information : ScriptableObject
{
    [SerializeField]
    private int AttackNum;
    public int P_AttackNum { get { return AttackNum; } set { AttackNum = value; } }
    [SerializeField]
    //애니메이션 배속
    private float animationPlaySpeed;
    public float P_animationPlaySpeed { get { return animationPlaySpeed; } set { animationPlaySpeed = value; } }

    [SerializeField]
    //해당 매니메이션 클립
    private AnimationClip aniclip;
    public AnimationClip P_aniclip { get { return aniclip; } set { aniclip = value; } }

    [SerializeField]
    //후딜레이
    private float MovementDelay;
    public float P_MovementDelay { get { return MovementDelay; } set { MovementDelay = value; } }
    [SerializeField]
    //다음동작으로 넘어가기 위한 시간
    //해당동작이 끝나고 해당 시간 안에 Attack()함수가 호출되어야지 다음동작으로 넘어간다.
    private float NextMovementTimeVal;
    public float P_NextMovementTimeVal { get { return NextMovementTimeVal; } set { NextMovementTimeVal = value; } }

    [SerializeField]
    private float damage;
    public float P_damage { get { return damage; } set { damage = value; } }

    [SerializeField]
    private float EffectStartTime;
    public float P_EffectStartTime { get { return EffectStartTime; } set { EffectStartTime = value; } }

    [SerializeField]
    private GameObject Effect;
    public GameObject P_Effect { get { return Effect; } set { Effect = value; } }

    [SerializeField]
    private Transform EffectPosRot;
    public Transform P_EffectPosRot { get { return EffectPosRot; } set { EffectPosRot = value; } }

    [SerializeField]
    private float movedis;
    public float P_movedis { get { return movedis; } set { movedis = value; } }

    [SerializeField]
    private float movetime;
    public float P_movetime { get { return movetime; } set { movetime = value; } }
}
