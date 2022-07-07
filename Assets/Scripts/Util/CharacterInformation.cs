using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]

public class CharacterInformation : ScriptableObject
{
    [SerializeField]
    private int player_HP;
    public int P_player_HP { get { return player_HP; } set { player_HP = value; } }

    [SerializeField]
    private int player_Def;
    public int P_player_Def { get { return player_Def; } set { player_Def = value; } }
    [SerializeField]
    private int player_MP;
    public int P_player_MP { get { return player_MP; } set { player_MP = value; } }
    [SerializeField]
    private int player_Stamina;
    public int P_player_Stamina { get { return player_Stamina; } set { player_Stamina = value; } }
    [SerializeField]
    private int player_mSpeed;
    public int P_player_mSpeed { get { return player_mSpeed; } set { player_mSpeed = value; } }
    [SerializeField]
    private int player_Balance;
    public int P_player_Balance { get { return player_Balance; } set { player_Balance = value; } }
    [SerializeField]
    private int player_Atk1;
    public int P_player_Atk1 { get { return player_Atk1; } set { player_Atk1 = value; } }
    [SerializeField]
    private int player_Stadown1;
    public int P_player_Stadown1 { get { return player_Stadown1; } set { player_Stadown1 = value; } }
    [SerializeField]
    private int player_MPup1;
    public int P_player_MPup1 { get { return player_MPup1; } set { player_MPup1 = value; } }
    [SerializeField]
    private int player_BalDown1;
    public int P_player_BalDown1 { get { return player_BalDown1; } set { player_BalDown1 = value; } }
    [SerializeField]
    private int player_Atk2;
    public int P_player_Atk2 { get { return player_Atk2; } set { player_Atk2 = value; } }
    [SerializeField]
    private int player_Stadown2;
    public int P_player_Stadown2 { get { return player_Stadown2; } set { player_Stadown2 = value; } }
    [SerializeField]
    private int player_MPup2;
    public int P_player_MPup2 { get { return player_MPup2; } set { player_MPup2 = value; } }
    [SerializeField]
    private int player_BalDown2;
    public int P_player_BalDown2 { get { return player_BalDown2; } set { player_BalDown2 = value; } }
    [SerializeField]
    private int player_Atk3;
    public int P_player_Atk3 { get { return player_Atk3; } set { player_Atk3 = value; } }
    [SerializeField]
    private int player_Stadown3;
    public int P_player_Stadown3 { get { return player_Stadown3; } set { player_Stadown3 = value; } }
    [SerializeField]
    private int player_MPup3;
    public int P_player_MPup3 { get { return player_MPup3; } set { player_MPup3 = value; } }
    [SerializeField]
    private int player_BalDown3;
    public int P_player_BalDown3 { get { return player_BalDown3; } set { player_BalDown3 = value; } }
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

  

    
}
