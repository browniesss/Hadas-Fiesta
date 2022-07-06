using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_aconstant : Information
{
    [SerializeField]
    private int Def;
    [SerializeField]
    private float Damege_Absorption;
    [SerializeField]
    private float Damege_Ratio;
    [SerializeField]
    private int NowHP;
    [SerializeField]
    private int Damege;

    public void Set(int Def, float Damege_Absorption, float Damege_Ratio, int NowHP, int Damege)
    {

        this.Def = Def;
        this.Damege_Absorption = Damege_Absorption;
        this.Damege_Ratio = Damege_Ratio;
        this.NowHP = NowHP;
        this.Damege = Damege;        
    }
}
