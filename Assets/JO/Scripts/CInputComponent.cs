using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputComponent : BaseComponent
{
    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.InputCom;
    }

    [System.Serializable]
    public class KeySetting
    {
        public KeyCode right = KeyCode.D;

        public KeyCode foward = KeyCode.W;

        public KeyCode left = KeyCode.A;

        public KeyCode back = KeyCode.S;

        public KeyCode Rolling = KeyCode.Space;

        public KeyCode Run = KeyCode.LeftShift;
    }

    public KeySetting _key = new KeySetting();

    //input에서 필요한 컴포넌트들

    //move 컴포넌트
    public CMoveComponent movecom;
    //Attack 컴포넌트
    public CAttackComponent attackcom;
    //Defence 컴포넌트
    public CDefenceComponent defencecom;
    
   

    void KeyInput()
    {
        if (movecom == null)
            movecom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;

        movecom.curval.IsMoving = false;

        float v = 0;
        float h = 0;

        movecom.MouseMove = new Vector2(0, 0);
        movecom.MoveDir = new Vector3(0, 0, 0);

        if(movecom.curval.IsAttacking)
        {
            return;
        }

        movecom.MouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        if (movecom.curval.IsRolling|| movecom.curval.IsSlip)
        {
            return;
        }

        Input.GetAxisRaw("Mouse ScrollWheel");//줌인 줌아웃에 사용

        if (Input.GetKey(_key.foward)) v += 1.0f;
        if (Input.GetKey(_key.back)) v -= 1.0f;
        if (Input.GetKey(_key.left)) h -= 1.0f;
        if (Input.GetKey(_key.right)) h += 1.0f;

        if (Input.GetKey(_key.Run)) movecom.curval.IsRunning = true;
        else movecom.curval.IsRunning = false;

        

        movecom.MoveDir = new Vector3(h, 0, v);

        if (Input.GetKey(_key.Rolling))
            movecom.Rolling();


        if (movecom.MoveDir.magnitude > 0 )
        {
            movecom.curval.IsMoving = true;
        }
    }


    void Update()
    {
        //왼쪽 마우스 클릭
        if(Input.GetMouseButtonDown(0))
        {
            attackcom.Attack();
            //movecom.curval.IsAttacking = true;
        }

        //오른쪽 마우스 클릭
        Input.GetMouseButtonDown(1);

        //키 입력
        KeyInput();
    }
}
