using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad_Save : Singleton<DataLoad_Save>
{
    [SerializeField]
    Dictionary<string, List<Information>> Dic_Data_Test = new Dictionary<string, List<Information>>();
    [SerializeField]
    List<CharacterInformation> PlayerDB_List = new List<CharacterInformation>();
    [SerializeField]
    public List<MonsterInformation> MonsterDB_List = new List<MonsterInformation>();
    [SerializeField]
    List<MonsterSkillInformation> MonsterSkillDB_List = new List<MonsterSkillInformation>();
    [SerializeField]
    List<MonsterTargetInformation> MonsterTargetDB_List = new List<MonsterTargetInformation>();
    [SerializeField]
    List<Player_aconstant> Player_A_constantDB_List = new List<Player_aconstant>();
    [SerializeField]
    List<Monster_aconstant> Monster_A_constantDB_List = new List<Monster_aconstant>();


    public void Init()
    {

        List<Dictionary<string, object>> Player_db_Dialog = LoadFile.Read("CSV/Player_DB");
        List<Dictionary<string, object>> Monster_db_Dialog = LoadFile.Read("CSV/Monster_DB");
        List<Dictionary<string, object>> MonsterSkill_db_Dialog = LoadFile.Read("CSV/MonsterSkill_DB");
        List<Dictionary<string, object>> MonsterTarget_db_Dialog = LoadFile.Read("CSV/MonsterTarget_DB");
        List<Dictionary<string, object>> Player_A_constant_db_Dialog = LoadFile.Read("CSV/Player_a constant_DB");
        List<Dictionary<string, object>> Monster_A_constant_db_Dialog = LoadFile.Read("CSV/Monster_a constant_DB");

        for (int i = 0; i < Player_db_Dialog.Count; i++)
        {
            CharacterInformation C_test = new CharacterInformation();
            C_test.set((int)Player_db_Dialog[i]["player_HP"]
                , (int)Player_db_Dialog[i]["player_Def"]
                , (int)Player_db_Dialog[i]["player_MP"]
                , (int)Player_db_Dialog[i]["player_Stamina"]
                , (int)Player_db_Dialog[i]["player_mSpeed"]
                , (int)Player_db_Dialog[i]["player_Balance"]
                , (int)Player_db_Dialog[i]["player_Atk1"]
                , (int)Player_db_Dialog[i]["player_Stadown1"]
                , (int)Player_db_Dialog[i]["player_MPup1"]
                , (int)Player_db_Dialog[i]["player_BalDown1"]
                , (int)Player_db_Dialog[i]["player_Atk2"]
                , (int)Player_db_Dialog[i]["player_Stadown2"]
                , (int)Player_db_Dialog[i]["player_MPup2"]
                , (int)Player_db_Dialog[i]["player_BalDown2"]
                , (int)Player_db_Dialog[i]["player_Atk3"]
                , (int)Player_db_Dialog[i]["player_Stadown3"]
                , (int)Player_db_Dialog[i]["player_MPup3"]
                , (int)Player_db_Dialog[i]["player_BalDown3"]
                );
            PlayerDB_List.Add(C_test);    
        }

        for (int i = 0; i < Monster_db_Dialog.Count; i++)
        {
            MonsterInformation C_Mon = new MonsterInformation();
            C_Mon.Set((int)Monster_db_Dialog[i]["Number"]
                , Monster_db_Dialog[i]["mon_Index"].ToString()
                , Monster_db_Dialog[i]["mon_nameKor"].ToString()
                , (int)Monster_db_Dialog[i]["mon_Default"]
                , (int)Monster_db_Dialog[i]["mon_Type"]
                , (int)Monster_db_Dialog[i]["mon_Position"]
                , (int)Monster_db_Dialog[i]["mon_MaxHP"]
                , (int)Monster_db_Dialog[i]["mon_Atk"]
                , (int)Monster_db_Dialog[i]["mon_Def"]
                , (int)Monster_db_Dialog[i]["mon_moveSpeed"]
                , (int)Monster_db_Dialog[i]["mon_Balance"]
                , (int)Monster_db_Dialog[i]["dieDelay"]
                );
            MonsterDB_List.Add(C_Mon);
        }

        for (int i = 0; i < MonsterSkill_db_Dialog.Count; i++)
        {
            MonsterSkillInformation C_MonSkill = new MonsterSkillInformation();
            C_MonSkill.Set(MonsterSkill_db_Dialog[i]["mon_Index"].ToString()
                , MonsterSkill_db_Dialog[i]["skill_Name_Kor"].ToString()
                , MonsterSkill_db_Dialog[i]["skill_Name_En"].ToString()
                , (int)MonsterSkill_db_Dialog[i]["skill_ID"]
                , (int)MonsterSkill_db_Dialog[i]["skill_Type"]
                , (int)MonsterSkill_db_Dialog[i]["skill_Targetyp"]              
                );
            MonsterSkillDB_List.Add(C_MonSkill);
        }

        for (int i = 0; i < MonsterTarget_db_Dialog.Count; i++)
        {
            MonsterTargetInformation C_MonTarget = new MonsterTargetInformation();
            C_MonTarget.Set((int)MonsterTarget_db_Dialog[i]["Target_Rank"]
                , (int)MonsterTarget_db_Dialog[i]["Number"]
                , (int)MonsterTarget_db_Dialog[i]["Character_ID"]
                , (int)MonsterTarget_db_Dialog[i]["target_Location1"]
                , (int)MonsterTarget_db_Dialog[i]["target_Location2"]
                , (int)MonsterTarget_db_Dialog[i]["target_Location3"]
                , (int)MonsterTarget_db_Dialog[i]["mon_Location1"]
                , (int)MonsterTarget_db_Dialog[i]["mon_Location2"]
                , (int)MonsterTarget_db_Dialog[i]["mon_Location3"]
                , (int)MonsterTarget_db_Dialog[i]["mon_Range"]
                );
            MonsterTargetDB_List.Add(C_MonTarget);
        }

        for (int i = 0; i < Player_A_constant_db_Dialog.Count; i++)
        {
            Player_aconstant C_Player_aconstant = new Player_aconstant();
            C_Player_aconstant.Set((int)Player_A_constant_db_Dialog[i]["Def"]
                , (float)Player_A_constant_db_Dialog[i]["Damege_Absorption"]
                , (float)Player_A_constant_db_Dialog[i]["Damege_Ratio"]
                , (int)Player_A_constant_db_Dialog[i]["NowHP"]
                , (int)Player_A_constant_db_Dialog[i]["Damege"]
                
                );
            Player_A_constantDB_List.Add(C_Player_aconstant);
        }

        for (int i = 0; i < Monster_A_constant_db_Dialog.Count; i++)
        {
            Monster_aconstant C_mon_aconstant = new Monster_aconstant();
            C_mon_aconstant.Set((int)Monster_A_constant_db_Dialog[i]["Def"]
               , (float)Monster_A_constant_db_Dialog[i]["Damege_Absorption"]
                , (float)Monster_A_constant_db_Dialog[i]["Damege_Ratio"]
                , (int)Monster_A_constant_db_Dialog[i]["NowHP"]
                , (int)Monster_A_constant_db_Dialog[i]["Damege"]
                );
            Monster_A_constantDB_List.Add(C_mon_aconstant);
        }

    }

    public MonsterInformation Get_MonsterDB(EnumScp.MonsterIndex testenum)
    {
        MonsterInformation testData = ScriptableObject.CreateInstance<MonsterInformation>();
        testData = MonsterDB_List[(int)testenum];
        return testData;
        
    }
    public CharacterInformation Get_PlayerDB(EnumScp.PlayerDBIndex testenum)
    {
        CharacterInformation testData = ScriptableObject.CreateInstance<CharacterInformation>();
        testData = PlayerDB_List[(int)testenum];
        return testData;
    }
    public MonsterSkillInformation Get_MonsterSkillDB(EnumScp.MonsterSkill testenum)
    {
        MonsterSkillInformation testData = ScriptableObject.CreateInstance<MonsterSkillInformation>();
        testData = MonsterSkillDB_List[(int)testenum];
        return testData;
    }
    public MonsterTargetInformation Get_MonsterTargetDB(EnumScp.MonsterTarget testenum)
    {
        MonsterTargetInformation testData = ScriptableObject.CreateInstance<MonsterTargetInformation>();
        testData = MonsterTargetDB_List[(int)testenum];
        return testData;
    }
    public Monster_aconstant Get_Monster_A_ConstantDB(EnumScp.A_Constant testenum)
    {
        Monster_aconstant testData = ScriptableObject.CreateInstance<Monster_aconstant>();
        testData = Monster_A_constantDB_List[(int)testenum];
        return testData;
    }
    public Player_aconstant Get_Player_A_ConstantDB(EnumScp.A_Constant testenum)
    {
        Player_aconstant testData = ScriptableObject.CreateInstance<Player_aconstant>();
        testData = Player_A_constantDB_List[(int)testenum];
        return testData;
    }

    void Start()
    {
        Init();
        //TestScp();
    }

    
    
}
