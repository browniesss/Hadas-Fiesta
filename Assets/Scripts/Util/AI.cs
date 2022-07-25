using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI
{
    public Battle_Character b_c;

    public State now_State;
    public List<State> pre_State_List;

    public NavMeshAgent navMesh;

    public void AI_Update()
    {
        foreach (var st in pre_State_List)
        {
            if (st.Judge(out now_State, b_c))
            {
                st.Run(b_c);
                return;
            }
        }

        if (now_State.Judge(out now_State, b_c))
        {
            now_State.Run(b_c);
        }
    }
}
