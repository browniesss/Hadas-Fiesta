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

    void Update()
    {
        state_handler.state = ai.AI_Update();
        state_handler.State_Handler_Update();
    }
}
