using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_AniScripts : MonoBehaviour
{
    [SerializeField]
    private AttackComponent attackcom;

    public void AttackEnd()
    {
        attackcom.AttackEnd(1);
    }
    public void Off_DoubleAttack_State()
    {
        attackcom.Off_NextAttack();
    }
    public void On_DoubleAttack_State()
    {
        attackcom.On_NextAttack();
    }
    void Start()
    {
        attackcom = GetComponentInParent<AttackComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
