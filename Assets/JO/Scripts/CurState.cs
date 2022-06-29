using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool isAttacked = false;
    [SerializeField]
    private bool isOutofControl = false;
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
    public bool IsCursorActive { get => isCursorActive; set => isCursorActive = value; }
    public bool IsFPP { get => isFPP; set => isFPP = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsRunning { get => isRunning; set => isRunning = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public bool IsFalling { get => isFalling; set => isFalling = value; }
    public bool IsSlip { get => isSlip; set => isSlip = value; }
    public bool IsFowordBlock { get => isFowordBlock; set => isFowordBlock = value; }
    public bool IsOnTheSlop { get => isOnTheSlop; set => isOnTheSlop = value; }
    public bool IsAttacked { get => isAttacked; set => isAttacked = value; }
    public bool IsOutofControl { get => isOutofControl; set => isOutofControl = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    //public float CurGravity { get => curGravity; set => curGravity = value; }
    public float LastJump { get => lastJump; set => lastJump = value; }
    public float CurGroundSlopAngle { get => curGroundSlopAngle; set => curGroundSlopAngle = value; }
    public float CurFowardSlopAngle { get => curFowardSlopAngle; set => curFowardSlopAngle = value; }
    public Vector3 CurGroundNomal { get => curGroundNomal; set => curGroundNomal = value; }
    public Vector3 CurGroundCross { get => curGroundCross; set => curGroundCross = value; }
    public Vector3 CurHorVelocity { get => curHorVelocity; set => curHorVelocity = value; }
    public Vector3 CurVirVelocity { get => curVirVelocity; set => curVirVelocity = value; }
    public float MoveAccel { get => moveAccel; set => moveAccel = value; }
}
