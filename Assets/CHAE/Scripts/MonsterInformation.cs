using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInformation : Information
{
    [SerializeField]
    private int Number;
    [SerializeField]
    private string mon_Index;
    [SerializeField]
    private string mon_nameKor;
    [SerializeField]
    private int mon_Default; //enum
    [SerializeField]
    private int mon_Type; //enum
    [SerializeField]
    private int mon_Position; //enum
    [SerializeField]
    private int mon_MaxHP;
    [SerializeField]
    private int mon_Atk;
    [SerializeField]
    private int mon_Def;
    [SerializeField]
    private int mon_Balance;
    [SerializeField]
    private int mon_moveSpeed;
    [SerializeField]
    private int dieDelay;
    [SerializeField]
    private int drop_Reward;

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
