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

    //input���� �ʿ��� ������Ʈ��

    //move ������Ʈ
    public CMoveComponent movecom;
    //Attack ������Ʈ

    //Defence ������Ʈ
    public CDefenceComponent defencecom;
    
   

    void KeyInput()
    {
        if (movecom == null)
            movecom = ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;


        float v = 0;
        float h = 0;

        movecom.MouseMove = new Vector2(0, 0);
        movecom.MoveDir = new Vector3(0, 0, 0);

        Input.GetAxisRaw("Mouse ScrollWheel");//���� �ܾƿ��� ���

        if (Input.GetKey(_key.foward)) v += 1.0f;
        if (Input.GetKey(_key.back)) v -= 1.0f;
        if (Input.GetKey(_key.left)) h -= 1.0f;
        if (Input.GetKey(_key.right)) h += 1.0f;

        if (Input.GetKey(_key.Run)) movecom.curval.IsRunning = true;
        else movecom.curval.IsRunning = false;

        movecom.MouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        movecom.MoveDir = new Vector3(h, 0, v);

        if (Input.GetKey(_key.Rolling))
            movecom.Rolling();


        if (movecom.MoveDir.magnitude > 0)
        {
            movecom.curval.IsMoving = true;
        }
        else
        {
            movecom.curval.IsMoving = false;
        }
    }


    void Update()
    {
        //���� ���콺 Ŭ��
        Input.GetMouseButtonDown(0);

        //������ ���콺 Ŭ��
        Input.GetMouseButtonDown(1);

        //Ű �Է�
        KeyInput();
    }
}
