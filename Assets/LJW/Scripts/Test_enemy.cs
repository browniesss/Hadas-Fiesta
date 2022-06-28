using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_enemy : Battle_Character
{
    void Start()
    {
        Initalize();
        ai.AI_Initialize(this);
    }

    protected override void Patrol_Enter_Process()
    {
        Debug.Log("패트롤 엔터");
    }

    new void Update()
    {
        base.state = ai.AI_Update();
        base.Update();
    }
}
