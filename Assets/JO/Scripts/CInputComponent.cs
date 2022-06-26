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
        [SerializeField]
        KeyCode right;
        [SerializeField]
        KeyCode foward;
        [SerializeField]
        KeyCode left;
        [SerializeField]
        KeyCode back;
        [SerializeField]
        KeyCode Rolling;
    }

    public KeySetting _keysetting = new KeySetting();

    public Vector2 MouseMove = Vector2.zero;

    public Vector3 MoveDir = Vector3.zero;

    //public CMoveComponent

    void KeyInput()
    {
        float v = 0;
        float h = 0;

        MouseMove = new Vector2(0, 0);
        MoveDir = new Vector3(0, 0, 0);

        Input.GetAxisRaw("Mouse ScrollWheel");//ÁÜÀÎ ÁÜ¾Æ¿ô¿¡ »ç¿ë

        if (Input.GetKey(KeyCode.W)) v += 1.0f;
        if (Input.GetKey(KeyCode.S)) v -= 1.0f;
        if (Input.GetKey(KeyCode.A)) h -= 1.0f;
        if (Input.GetKey(KeyCode.D)) h += 1.0f;

        MouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        
        MoveDir = new Vector3(h, 0, v);

        if (MouseMove.magnitude > 0)
            ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.MoveCom);

    }

    void Start()
    {
        
    }

    void Update()
    {
        Input.GetMouseButtonDown(0);

        Input.GetMouseButtonDown(1);

        KeyInput();
    }
}
