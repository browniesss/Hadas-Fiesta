using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character3DMove: MonoBehaviour
{
    //[Header("============components============")]
    
    [System.Serializable]
    public class Com
    {
        public Transform CharacterRoot = null;

        public Transform TpCamRig = null;
        public Transform TpCam = null;

        public Transform FpRoot = null;
        public Transform FpCamRig = null;
        public Transform FpCam = null;

        public Rigidbody CharacterRig = null;

        public CapsuleCollider CapsuleCol = null;

        public CAnimationComponent animator = null;
    }


    public Com com = new Com();

    [Header("============Now Values============")]

    public Vector2 MouseMove = Vector2.zero;

    public Vector3 MoveDir = Vector3.zero;

    public Vector3 WorldMove = Vector3.zero;

    public bool IsCursorActive = false;

    public bool IsFPP = true;

    public bool IsMoving = false;

    public bool IsRunning = false;

    public bool IsGrounded = false;

    public bool IsJumping = false;

    public bool IsFalling = false;

    public bool IsSlip = false;

    public float CurGravity;//현재 벨로시티의 y값

    private float LastJump;

    public float CurGroundSlopAngle;

    public float CurFowardSlopAngle;

    public Vector3 CurGroundNomal;

    public Vector3 CurGroundCross;

    public Vector3 CurHorVelocity;

    public float MoveAccel;

    //public Vector3 Capsuletopcenter = Vector3.zero;

    //public Vector3 Capsulebottomcenter = Vector3.zero;

    public Vector3 Capsuletopcenter => new Vector3(transform.position.x, transform.position.y + com.CapsuleCol.height - com.CapsuleCol.radius, transform.position.z);
    public Vector3 Capsulebottomcenter => new Vector3(transform.position.x, transform.position.y + com.CapsuleCol.radius, transform.position.z);

    [Header("============Options============")]

    public float RotMouseSpeed = 10f;

    public float MoveSpeed;

    public float MinAngle;

    public float MaxAngle;

    public float Gravity;//중력값(프레임단위로 증가시켜줄 값)

    public float JumpPower = 120;//점프를 하면 해당 값으로 curgravity값을 바꿔준다.

    public float JumpcoolTime = 1f;

    public LayerMask GroundMask;

    public float MaxSlop = 70;


    [Header("============TestVals============")]

    public Vector3 updown;
    public float xnext;

    public Vector3 rightleft;
    public float ynext;

    public Vector3 testtart;
    public Vector3 testend;


    public Transform testcube;

    void KeyInput()
    {
        float v = 0;
        float h = 0;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChaingePerspective();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShowCursorToggle();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!IsRunning)
                IsRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (IsRunning)
                IsRunning = false;
        }

        if (Input.GetKey(KeyCode.W)) v += 1.0f;
        if (Input.GetKey(KeyCode.S)) v -= 1.0f;
        if (Input.GetKey(KeyCode.A)) h -= 1.0f;
        if (Input.GetKey(KeyCode.D)) h += 1.0f;



        MouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        MoveDir = new Vector3(h, 0, v);
        IsMoving = (MoveDir.sqrMagnitude > 0.01f);
        if (IsMoving)
        {
            MoveAccel = Mathf.Lerp(MoveAccel, 1.0f, 0.1f);
            if (com.animator == null)
            {
                com.animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom);
            }
            com.animator.SetBool("Idle",false);
            com.animator.SetBool("Move", true);

        }
        else
        {
            if (com.animator == null)
            {
                com.animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom);
            }
            MoveAccel = Mathf.Lerp(MoveAccel, 0.0f, 0.1f);
            com.animator.SetBool("Idle", true);
            com.animator.SetBool("Move", false);

        }
    }

    public void Move()
    {

        MoveDir.Normalize();

        if (IsFPP)
            WorldMove = com.FpRoot.TransformDirection(MoveDir);
        else
            WorldMove = com.TpCamRig.TransformDirection(MoveDir);


        WorldMove *= MoveSpeed;

        if (IsSlip)
        {
            Vector3 temp = -CurGroundCross;
            com.CharacterRig.velocity = new Vector3(WorldMove.x, CurGravity, WorldMove.z);
        }
        else
        {
            com.CharacterRig.velocity = new Vector3(WorldMove.x, CurGravity, WorldMove.z);//이전에 사용했던 무브
            //com.CharacterRig.velocity = new Vector3(CurHorVelocity.x*MoveAccel, CurGravity, CurHorVelocity.z* MoveAccel);//이건 슬립상태일때만 이용하도록
        }

    }

    private void ShowCursorToggle()
    {
        IsCursorActive = !IsCursorActive;
        ShowCursor(IsCursorActive);
    }

    private void ShowCursor(bool value)
    {
        Cursor.visible = value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }



    public void CheckFront()
    {
        RaycastHit hit;
        CurFowardSlopAngle = 0;
        bool cast = Physics.CapsuleCast(Capsuletopcenter, Capsulebottomcenter, com.CapsuleCol.radius, WorldMove + Vector3.down, out hit, 5.0f, GroundMask);
        if (cast)
        {
            CurFowardSlopAngle = Vector3.Angle(hit.normal, Vector3.up);



        }

    }

    private void OnDrawGizmosSelected()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Capsuletopcenter, com.CapsuleCol.radius);
        Gizmos.DrawWireSphere(Capsulebottomcenter, com.CapsuleCol.radius);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(testtart, testend);

        if (CurFowardSlopAngle != 0)
        {

        }
    }

    public void CheckGround()
    {
        IsGrounded = false;
        IsSlip = false;
        CurGroundSlopAngle = 0;
        if (Time.time >= LastJump + 0.2f)//점프하고 0.2초 동안은 지면검사를 하지 않는다.
        {
            //Debug.Log("바닥");
            RaycastHit hit;
            testtart = com.CapsuleCol.transform.position;
            testend = testtart + Vector3.down * 0.2f;
            //Debug.DrawRay(testtart, Vector3.down, Color.yellow);
            bool cast = Physics.SphereCast(Capsulebottomcenter, com.CapsuleCol.radius - 0.2f, Vector3.down, out hit, com.CapsuleCol.radius + 0.1f);

            //testcube.transform.position = com.CapsuleCol.transform.position;
            //bool cast = Physics.SphereCast(com.CapsuleCol.transform.position, com.CapsuleCol.radius - 0.2f, Vector3.down, out hit, 0.2f, GroundMask);
            if (cast)
            {
                //Debug.Log("뭔가 들어옴");
                IsGrounded = true;
                CurGroundSlopAngle = Vector3.Angle(hit.normal, Vector3.up);
                CurGroundNomal = hit.normal;
                if (CurGroundSlopAngle >= MaxSlop)
                {
                    IsSlip = true;
                }
                else
                {
                    IsSlip = false;
                }
                Debug.Log("바닥");
                //if (hit.transform.tag == "Ground")
                //{
                //    //Debug.Log("바닥");
                    
                //}
                
            }
        }
        CurGroundCross = Vector3.Cross(CurGroundNomal, Vector3.up);
    }


    //모든 회전이 완료된 다음에 동작해야 한다.
    //x,z축의 움직임을 담당 y축의 움직임은 따로 관리
    public void HorVelocity()
    {
        CurHorVelocity = com.FpCamRig.forward;


        if (IsSlip)
        {
            //움직임을 현재 바닥 경사각의 -로 해서 회전을 시킴
        }
        CurHorVelocity = Quaternion.AngleAxis(-CurGroundSlopAngle, CurGroundCross) * CurHorVelocity;//이럭식으로 벡터를 회전시킬 수 있다. 역은 성립하지 않는다.

    }

    public void Falling()
    {
        float deltacof = Time.deltaTime * 10f;
        
        if (IsGrounded)
        {
            CurGravity = 0;
            Gravity = 1;
        }
        else
        {
            Gravity += 0.098f;
            CurGravity -= deltacof * Gravity;
        }
    }

    public void Jump()
    {
        if (Time.time >= LastJump + JumpcoolTime)
        {
            LastJump = Time.time;
            IsJumping = true;
            CurGravity = JumpPower;
        }

    }


    public void Rotation()
    {
        //1 인칭 일때
        //fp root로 좌우회전
        //fp cam rig로 상하회전
        if (IsFPP)
        {
            RotateFP();
        }
        else//3 인칭 일때
        //fp root로 좌우회전
        //tp cam rig로 좌우 및 상하회전
        {
            RotateTP();
            RotateTPFP();
        }
    }

    //1인칭일때회전 3인칭은 놔두고 1인칭 캐릭터만 회전시켜 준다.
    public void RotateFP()
    {
        float xRotPrev = com.FpRoot.localEulerAngles.y;
        float xRotNext = xRotPrev + MouseMove.x * Time.deltaTime * 50f * RotMouseSpeed;
        xnext = xRotNext;
        //if (xRotNext > 180f)
        //    xRotNext -= 360f;

        float yRotPrev = com.FpCamRig.localEulerAngles.x;
        float yRotNext = yRotPrev + MouseMove.y * Time.deltaTime * 50f * RotMouseSpeed;
        ynext = yRotNext;


        com.FpRoot.localEulerAngles = Vector3.up * xRotNext;
        updown = com.FpRoot.localEulerAngles;
        com.FpCamRig.localEulerAngles = Vector3.right * yRotNext;
        rightleft = com.FpCamRig.localEulerAngles;

    }


    //3인칭일때
    public void RotateTP()
    {
        float xRotPrev = com.TpCamRig.localEulerAngles.y;
        float xRotNext = xRotPrev + MouseMove.x * Time.deltaTime * 50f * RotMouseSpeed;

        //if (xRotNext > 180f)
        //    xRotNext -= 360f;

        float yRotPrev = com.TpCamRig.localEulerAngles.x;
        float yRotNext = yRotPrev + MouseMove.y * Time.deltaTime * 50f * RotMouseSpeed;



        //TpCamRig.localEulerAngles = Vector3.up * xRotNext;

        //TpCamRig.localEulerAngles = Vector3.right * yRotNext;

        com.TpCamRig.localEulerAngles = new Vector3(yRotNext, xRotNext, 0);
    }

    //이떄는 마우스로움직이는게아니고 키보드 입력에 따라서  회전 해야 하기때문에 따로 만듦
    public void RotateTPFP()
    {

        WorldMove = com.TpCamRig.TransformDirection(MoveDir);
        float curRotY = com.FpRoot.localEulerAngles.y;
        float nextRotY = Quaternion.LookRotation(WorldMove, Vector3.up).eulerAngles.y;

        if (!IsMoving) nextRotY = curRotY;

        if (nextRotY - curRotY > 180f) nextRotY -= 360f;
        else if (curRotY - nextRotY > 180f) nextRotY += 360f;


        com.FpRoot.eulerAngles = Vector3.up * Mathf.Lerp(curRotY, nextRotY, 0.1f);
    }




    void ChaingePerspective()
    {
        IsFPP = !IsFPP;
        com.FpCam.gameObject.SetActive(IsFPP);
        com.TpCam.gameObject.SetActive(!IsFPP);
    }

    private void Awake()
    {
        
        ChaingePerspective();
        ShowCursor(false);


    }

    // Start is called before the first frame update
    void Start()
    {
        com.animator = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;
    }

    // Update is called once per frame
    void Update()
    {
        Falling();
        KeyInput();

        CheckGround();
        CheckFront();

        Rotation();
        HorVelocity();
        Move();
    }
}
