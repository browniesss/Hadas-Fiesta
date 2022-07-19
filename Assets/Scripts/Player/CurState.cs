using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//move에서 사용하는 변수들
//해당 값이 변경되면 해당되는 state 변경이 필요
[System.Serializable]
public class CurState
{
    [SerializeField]
    private bool isCursorActive = false;
    [SerializeField]
    private bool isFPP = true;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    private bool isRunning = false;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private bool isJumping = false;
    [SerializeField]
    private bool isFalling = false;
    [SerializeField]
    private bool isSlip = false;
    [SerializeField]
    private bool isFowordBlock = false;
    [SerializeField]
    private bool isOnTheSlop = false;
    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private bool isGuard = false;
    [SerializeField]
    private bool isKnockBack = false;
    [SerializeField]
    private bool isKnockDown = false;


    //[SerializeField]
    //private bool isAttacked = false;
    //[SerializeField]
    //private bool isOutofControl = false;
    [SerializeField]
    private bool isRolling = false;
    [SerializeField]
    private float lastJump;
    [SerializeField]
    private float curGroundSlopAngle;
    [SerializeField]
    private float curFowardSlopAngle;
    [SerializeField]
    private Vector3 curGroundNomal;
    [SerializeField]
    private Vector3 curGroundCross;
    [SerializeField]
    private Vector3 curHorVelocity;
    [SerializeField]
    private Vector3 curVirVelocity;
    [SerializeField]
    private float moveAccel;

    //public Vector2 MouseMove { get => mouseMove; set => mouseMove = value; }
    //public Vector3 MoveDir { get => moveDir; set => moveDir = value; }
    //public Vector3 WorldMove { get => worldMove; set => worldMove = value; }
    public bool IsCursorActive { 
        get => isCursorActive; 
        set => isCursorActive = value; 
    }
    public bool IsFPP { 
        get => isFPP; 
        set => isFPP = value; 
    }
    public bool IsMoving { 
        get
        {
            return isMoving;
        }
        set
        {
            isMoving = value;
            if (isMoving)
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Move);
            //else
            //    CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
        }
    }
    public bool IsRunning { 
        get
        {
            return isRunning;
        }
        set
        {
            isRunning = value;
        }
    }
    public bool IsGrounded { 
        get => isGrounded;
        set => isGrounded = value; 
    }
    public bool IsJumping { 
        get => isJumping; 
        set => isJumping = value; 
    }
    public bool IsFalling { 
        get
        {
            return isFalling;
        }
        set
        {
            isFalling = value;
        } 
    }
    public bool IsSlip { 
        get
        {
            return isSlip;
        }
        set
        {
            isSlip = value;
        }
    }
    public bool IsFowordBlock { 
        get => isFowordBlock; 
        set => isFowordBlock = value;
    }
    public bool IsOnTheSlop { 
        get => isOnTheSlop; 
        set => isOnTheSlop = value; 
    }
    //public bool IsAttacked { get => isAttacked; set => isAttacked = value; }
    //public bool IsOutofControl { 
    //    get
    //    {
    //        return isOutofControl;
    //    }
    //    set
    //    {
    //        isOutofControl = value;
    //    }
    //}
    public bool IsRolling { 
        get
        {
            return isRolling;
        }
        set
        {
            isRolling = value;
            if (isRolling)
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Rolling);
            }
            else
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
            }
        }
    }
    public float LastJump { 
        get => lastJump; 
        set => lastJump = value;
    }
    public float CurGroundSlopAngle { 
        get => curGroundSlopAngle; 
        set => curGroundSlopAngle = value; 
    }
    public float CurFowardSlopAngle { 
        get => curFowardSlopAngle; 
        set => curFowardSlopAngle = value; 
    }
    public Vector3 CurGroundNomal { 
        get => curGroundNomal; 
        set => curGroundNomal = value; 
    }
    public Vector3 CurGroundCross { 
        get => curGroundCross; 
        set => curGroundCross = value; 
    }
    public Vector3 CurHorVelocity { 
        get => curHorVelocity; 
        set => curHorVelocity = value; 
    }
    public Vector3 CurVirVelocity { 
        get => curVirVelocity; 
        set => curVirVelocity = value;
    }
    public float MoveAccel { 
        get
        {
            return moveAccel;
        }
        set
        {
            moveAccel = value;
        }
    }
    public bool IsAttacking { 
        get
        {
            return isAttacking;
        }
        set
        {
            isAttacking = value;
            if (isAttacking)
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Attack);
            }
            else
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
            }
        }  
    }
    public bool IsGuard { 
        get
        {
            return isGuard;
        }
        set
        {
            isGuard = value;

            if (isGuard)
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Guard);
                //Debug.Log("guard들어옴");
            }
            else
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
                //Debug.Log("guard나감");
            }
                

        }
    }

    public bool IsKnockBack { 
        get
        {
            return isKnockBack;
        }
        set
        {
            isKnockBack = value;

            if (isKnockBack)
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.OutOfControl);
            }
            else
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
            }
        }
    }
    public bool IsKnockDown {
        get
        {
            return IsKnockDown;
        }
        set
        {
            IsKnockDown = value;

            if (IsKnockDown)
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.OutOfControl);
            }
            else
            {
                CharacterStateMachine.Instance.SetState(CharacterStateMachine.eCharacterState.Idle);
            }
        }
    }
}
