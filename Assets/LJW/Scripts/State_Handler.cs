using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Handler : MonoBehaviour
{
    [SerializeField]
    protected State state;

    void Start()
    {

    }

    protected void Update()
    {
        switch (state)
        {
            case State.Patrol_Enter:
                Patrol_Enter_Process();
                break;
            case State.Patrol:
                Patrol_Process();
                break;
            case State.Trace:
                Trace_Process();
                break;
            case State.Attack:
                Attack_Process();
                break;
        }
    }

    protected virtual void Patrol_Enter_Process()
    {

    }

    protected virtual void Patrol_Process()
    {

    }

    protected virtual void Patrol_Exit_Process()
    {

    }

    protected virtual void Trace_Process()
    {

    }

    protected virtual void Attack_Process()
    {

    }
}
