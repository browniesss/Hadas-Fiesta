using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoubleAttack_Action : MonoBehaviour
{
    UnityEvent AttackEvent;
    [SerializeField]
    private bool NextAttack = false;
    [SerializeField]
    private bool NextAttack_Possible = false;
    void Start()
    {
        NextAttack_Possible = false;

        if (AttackEvent == null)
        {
            AttackEvent = new UnityEvent();
            AttackEvent.AddListener(DoubleAttack_Confirm);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && AttackEvent != null && NextAttack_Possible)
        {
            Debug.Log("지금이니");
        }
    }
    public void Remove_AttackEvent()
    {
        if (AttackEvent != null)
        {
            AttackEvent.RemoveListener(DoubleAttack_Confirm);
        }
    }
    public void Add_AttackEvent()
    {
        if (AttackEvent == null)
        {
            AttackEvent.RemoveListener(DoubleAttack_Confirm);
        }
    }
    public void On_DoubleAttack_State()
    {
        Debug.Log("On");
        NextAttack_Possible = true;
    }
    public void Off_DoubleAttack_State()
    {
        Debug.Log("off");
        NextAttack_Possible = false;
    }
    public void DoubleAttack_Confirm()
    {

    }
}
