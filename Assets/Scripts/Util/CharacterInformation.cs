using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : Information
{
    [SerializeField]
    private int player_HP;
    [SerializeField]
    private int player_Def;
    [SerializeField]
    private int player_MP;
    [SerializeField]
    private int player_Stamina;
    [SerializeField]
    private int player_mSpeed;
    [SerializeField]
    private int player_Balance;
    [SerializeField]
    private int player_Atk1;
    [SerializeField]
    private int player_Stadown1;
    [SerializeField]
    private int player_MPup1;
    [SerializeField]
    private int player_BalDown1;
    [SerializeField]
    private int player_Atk2;
    [SerializeField]
    private int player_Stadown2;
    [SerializeField]
    private int player_MPup2;
    [SerializeField]
    private int player_BalDown2;
    [SerializeField]
    private int player_Atk3;
    [SerializeField]
    private int player_Stadown3;
    [SerializeField]
    private int player_MPup3;
    [SerializeField]
    private int player_BalDown3;
    public void set(int hp, int def, int mp, int stamina, int mspeed, int balance, int atk1, int stadown1, int mpup1, int baldown1, int atk2, int stadown2, int mpup2, int baldown2, int atk3, int stadown3, int mpup3, int baldown3)
    {
        player_HP = hp;
        player_Def = def;
        player_MP = mp;
        player_Stamina = stamina;
        player_mSpeed = mspeed;
        player_Balance = balance;
        player_Atk1 = atk1;
        player_Stadown1 = stadown1;
        player_MPup1 = mpup1;
        player_BalDown1 = baldown1;
        player_Atk2 = atk2;
        player_Stadown2 = stadown2;
        player_MPup2 = mpup2;
        player_BalDown2 = baldown2;
        player_Atk3 = atk3;
        player_Stadown3 = stadown3;
        player_MPup3 = mpup3;
        player_BalDown3 = baldown3;
    }

    public int get()
    {
        return player_Stadown3;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
