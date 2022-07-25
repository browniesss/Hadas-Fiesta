using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAround : MonoBehaviour
{
    CurState curval;
    CMoveComponent movecom;


    public CapsuleCollider CapsuleCol = null;
    public Vector3 Capsuletopcenter => new Vector3(transform.position.x, transform.position.y + CapsuleCol.height - CapsuleCol.radius, transform.position.z);
    public Vector3 Capsulebottomcenter => new Vector3(transform.position.x, transform.position.y + CapsuleCol.radius, transform.position.z);

    private void Awake()
    {
        CapsuleCol = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        if(movecom==null)
        {
            movecom = PlayableCharacter.Instance.GetMyComponent(EnumTypes.eComponentTypes.MoveCom) as CMoveComponent;
            curval = movecom.curval;
        }
        
    }

    public void CheckFront()
    {
        RaycastHit hit;
        curval.CurFowardSlopAngle = 0;
        curval.IsFowordBlock = false;
        //Vector3 temp = new Vector3(WorldMove.x, 0, WorldMove.z);
        //temp = com.FpRoot.forward /*+ Vector3.down*/;
        bool cast = Physics.CapsuleCast(Capsuletopcenter, Capsulebottomcenter, CapsuleCol.radius - 0.2f, movecom.com.FpRoot.forward, out hit, 0.3f);
        if (cast)
        {
            curval.CurFowardSlopAngle = Vector3.Angle(hit.normal, Vector3.up);
            if (curval.CurFowardSlopAngle >= 70.0f)
            {
                curval.IsFowordBlock = true;
            }
        }
    }


    public void CheckGround()
    {
        curval.IsGrounded = false;
        curval.IsSlip = false;
        curval.IsOnTheSlop = false;
        curval.CurGroundSlopAngle = 0;
        if (Time.time >= curval.LastJump + 0.2f)//점프하고 0.2초 동안은 지면검사를 하지 않는다.
        {
            RaycastHit hit;

            bool cast = Physics.SphereCast(Capsulebottomcenter, CapsuleCol.radius - 0.2f, Vector3.down, out hit, CapsuleCol.radius - 0.1f);

            if (cast)
            {
                curval.IsGrounded = true;
                curval.CurGroundNomal = hit.normal;
                curval.CurGroundSlopAngle = Vector3.Angle(hit.normal, Vector3.up);

                curval.CurFowardSlopAngle = Vector3.Angle(hit.normal, movecom.com.FpRoot.forward) - 90f;

                if (curval.CurGroundSlopAngle > 1.0f)
                {
                    curval.IsOnTheSlop = true;
                    if (curval.CurGroundSlopAngle >= movecom.moveoption.MaxSlop)
                    {
                        curval.IsSlip = true;
                    }
                }
                curval.CurGroundCross = Vector3.Cross(curval.CurGroundNomal, Vector3.up);

            }
        }

    }

    private void Update()
    {
        CheckFront();
        CheckGround();

    }

}
