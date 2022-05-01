using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Warrior : Enemy
{
    void Start()
    {
        parent_Init();
    }

    protected override void Enemy_FSM()
    {
        switch (cur_State)
        {
            case 1:
                Enemy_Patrol();
                break;
            case 2:
                Enemy_Trace();
                break;
            case 3:
                break;
            case 4:
                Enemy_Return();
                break;
        }
    }

    void Update()
    {
        Enemy_FSM();
    }
}
