using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
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

    protected override void Enemy_Attack()
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        Enemy_FSM();
    }
}
