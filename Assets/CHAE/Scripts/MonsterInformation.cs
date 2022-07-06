using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = int.MaxValue)]
public class MonsterInformation : ScriptableObject
{
    [SerializeField]
    private int Number;
    public int P_Number { get { return Number; } set { Number = value; } }
    [SerializeField]
    private string mon_Index;
    public string P_mon_Index { get { return mon_Index; } }
    [SerializeField]
    private string mon_nameKor;
    public string P_mon_nameKor { get { return mon_nameKor; } }
    [SerializeField]
    private int mon_Default; //enum
    public int P_mon_Default { get { return mon_Default; } }
    [SerializeField]
    private int mon_Type; //enum
    public int P_mon_Type { get { return mon_Type; } }
    [SerializeField]
    private int mon_Position; //enum
    public int P_mon_Position { get { return mon_Position; } }
    [SerializeField]
    private int mon_MaxHP;
    public int P_mon_MaxHP { get { return mon_MaxHP; } }
    [SerializeField]
    private int mon_Atk;
    public int P_mon_Atk { get { return mon_Atk; } }
    [SerializeField]
    private int mon_Def;
    public int P_mon_Def { get { return mon_Def; } }
    [SerializeField]
    private int mon_Balance;
    public int P_mon_Balance { get { return mon_Balance; } }
    [SerializeField]
    private int mon_moveSpeed;
    public int P_mon_moveSpeed { get { return mon_moveSpeed; } }
    [SerializeField]
    private int dieDelay;
    public int P_dieDelay { get { return dieDelay; } }
    [SerializeField]
    private int drop_Reward;
    public int P_drop_Reward{ get { return drop_Reward; } }

    public void Set(int num, string mon_index, string mon_namekor, int mon_default, int mon_type, int mon_position, int mon_hp, int mon_atk, int mon_def, int mon_balance, int mon_movespeed, int diedelay)
    {
        Number = num;
        mon_Index = mon_index;
        mon_nameKor = mon_namekor;
        mon_Default = mon_default;
        mon_Type = mon_type;
        mon_Position = mon_position;
        mon_MaxHP = mon_hp;
        mon_Atk = mon_atk;
        mon_Def = mon_def;
        mon_Balance = mon_balance;
        mon_moveSpeed = mon_movespeed;
        dieDelay = diedelay;
        
    }

   
}
