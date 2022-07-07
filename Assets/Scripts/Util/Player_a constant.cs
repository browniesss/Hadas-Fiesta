using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_A_Constant Data", menuName = "Scriptable Object/Player_A_Constant Data", order = int.MaxValue)]
public class Player_aconstant : ScriptableObject
{
    [SerializeField]
    private int Def;
    public int P_Def { get { return Def; } set { Def = value; } }
    [SerializeField]
    private float Damege_Absorption;
    public float P_Damege_Absorption { get { return Damege_Absorption; } set { Damege_Absorption = value; } }
    [SerializeField]
    private float Damege_Ratio;
    public float P_Damege_Ratio { get { return Damege_Ratio; } set { Damege_Ratio = value; } }
    [SerializeField]
    private int NowHP;
    public int P_NowHP { get { return NowHP; } set { NowHP = value; } }
    [SerializeField]
    private int Damege;
    public int P_Damege { get { return Damege; } set { Damege = value; } }

    public void Set(int Def, float Damege_Absorption, float Damege_Ratio, int NowHP, int Damege)
    {

        this.Def = Def;
        this.Damege_Absorption = Damege_Absorption;
        this.Damege_Ratio = Damege_Ratio;
        this.NowHP = NowHP;
        this.Damege = Damege;        
    }
}
