using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class AI
{
    public Battle_Character b_c;

    public State now_State;
    public List<State> pre_State_List;

    public NavMeshAgent navMesh;

    public void AI_Init(Battle_Character b_c)
    {
        this.b_c = b_c;

        navMesh = b_c.GetComponent<NavMeshAgent>();
    }

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
