using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Patrol : State
{
    public override bool Judge(out State _State, Battle_Character b_c)
    {
        Collider[] cols = Physics.OverlapSphere(b_c.transform.position,
            b_c.mon_find_Range);
        //, 1 << 8); // 비트 연산자로 8번째 레이어

        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Player")
                {
                    b_c.cur_Target = cols[i].gameObject;
                    _State = Trans_List[0];
                    return false;
                }
            }
        }

        _State = this;
        return true;
    }

    public override void Run(Battle_Character b_c)
    {
        Vector3 charPos = new Vector3(b_c.transform.position.x,
            0, b_c.transform.position.z);
        Vector3 desPos = new Vector3(b_c.destination_Pos.x
            , 0, b_c.destination_Pos.z);

        if (Vector3.Distance(charPos, desPos) <= 1f)
        {
            if (!b_c.patrol_Start)
            {
                StartCoroutine(patrol_Think_Coroutine(b_c));
                b_c.patrol_Start = true;

                //anim.SetBool("isWalk", false);
            }
        }
        else
        {
            b_c.real_AI.navMesh.SetDestination(b_c.destination_Pos);
        }
    }

    protected IEnumerator patrol_Think_Coroutine(Battle_Character b_c)  // 다음 목적지 생각하는 코루틴
    {
        yield return new WaitForSeconds(1f);

        int randX = Random.Range(-10, 10);
        int randZ = Random.Range(-10, 10);

        b_c.destination_Pos = new Vector3(b_c.return_Pos.x + randX, b_c.return_Pos.y, b_c.return_Pos.z + randZ);

        b_c.patrol_Start = false;
    }
}
