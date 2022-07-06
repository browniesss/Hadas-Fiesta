using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad_Save : MonoBehaviour
{
    [SerializeField]
    Dictionary<string, List<Information>> Dic_Data_Test = new Dictionary<string, List<Information>>();
    [SerializeField]
    List<CharacterInformation> test_list = new List<CharacterInformation>();

    public void Init()
    {

        List<Dictionary<string, object>> Player_db_Dialog = LoadFile.Read("Player_DB");
        //List<Dictionary<string, object>> Player_db_Dialog = LoadFile.Read("TestPlayer");

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
            test_list.Add(C_test);    
        }
        


    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
