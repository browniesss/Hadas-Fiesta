using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//레벨이 변할때마다 캐릭터 스탯 정보들을 받아와서 초기화 해준다.
public class BaseStatus
{
    [Header("=========================")]
    [Header("Status")]
    [SerializeField]
    private int curLevel;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float curHP;
    [SerializeField]
    private float maxStamina;
    [SerializeField]
    private float curStamina;
    [SerializeField]
    private float damage;//공격력
    [SerializeField]
    private float defense;//방어력
    [SerializeField]
    private float maxBalance;
    [SerializeField]
    private float curBalance;
    [SerializeField]
    private float maxMP;
    [SerializeField]
    private float curMP;
    [SerializeField]
    private int curExp;
    [SerializeField]
    private int nextExp;


    [SerializeField]
    public CharacterInformation CharacterDBInfo;
    [SerializeField]
    private DataLoad_Save DBController;


    public int CurLevel 
    { 
        get
        {
            return curLevel;
        }
        set
        {
            curLevel = value;
            if(curLevel==1)
            {
                CharacterDBInfo = DBController.Get_PlayerDB(EnumScp.PlayerDBIndex.Level1);
                MaxHP = CharacterDBInfo.P_player_HP;
                MaxStamina = CharacterDBInfo.P_player_Stamina;
                MaxBalance = CharacterDBInfo.P_player_Balance;
                MaxMP = CharacterDBInfo.P_player_MP;

            }
        }
    }
    public float MaxHP 
    { 
        get => maxHP; 
        set
        {
            maxHP = value;
            CurHP = maxHP;
        }
    }

    public float CurHP 
    { 
        get => curHP; 
        set
        {
            curHP = value;
            Debug.Log($"현재 HP 변화 {curHP}");
        }
    }
    
    public float MaxStamina 
    { 
        get => maxStamina; 
        set
        {
            maxStamina = value;
            CurStamina = maxStamina;
        }
    }
    public float CurStamina 
    { 
        get => curStamina; 
        set => curStamina = value; 
    }
    public float MaxBalance 
    { 
        get => maxBalance;
        set
        {
            maxBalance = value;
            CurBalance = maxBalance;
        }
    }
    public float CurBalance 
    { 
        get => curBalance; 
        set => curBalance = value; 
    }
    public float MaxMP 
    { 
        get => maxMP;
        set
        {
            maxMP = value;
            CurMP = maxMP;
        }
    }
    public float CurMP 
    { 
        get => curMP; 
        set => curMP = value; 
    }
    public int CurExp 
    { 
        get => curExp; 
        set => curExp = value; 
    }
    public int NextExp 
    { 
        get => nextExp; 
        set => nextExp = value; 
    }
    public float Damage 
    { 
        get => damage; 
        set => damage = value; 
    }
    public float Defense 
    { 
        get => defense; 
        set => defense = value; 
    }

    public void Init(DataLoad_Save DBController)
    {
        this.DBController = DBController;
        CurLevel = 1;
    }
}
