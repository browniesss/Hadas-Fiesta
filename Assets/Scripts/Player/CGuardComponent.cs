using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGuardComponent : BaseComponent
{
    [Header("Guard Options")]
    public float GuardTime;//최대로 가드를 할 수 있는 시간
    public int MaxGuardGauge;//

    [Header("Cur Values")]
    public int CurGuardGauge;
    public bool nowGuard;
    public float GaugeDownInterval;


        
    public void Guard()
    {

    }

    //
    public void GaugeDown()
    {

    }




    public override void InitComtype()
    {
        p_comtype = EnumTypes.eComponentTypes.GuardCom;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
