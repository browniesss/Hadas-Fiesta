using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPTEST : MonoBehaviour
{

    //테스트용 몬스터 스크립트 

    public MonsterInformation data;
    public CharacterInformation pdata;
    public DataLoad_Save TestDataLoad;


    

    void Start()
    {
        
        data = ScriptableObject.CreateInstance<MonsterInformation>();
        data = DataLoad_Save.Instance.Get_MonsterDB(EnumScp.MonsterIndex.mon_02_01);
        pdata = DataLoad_Save.Instance.Get_PlayerDB(EnumScp.PlayerDBIndex.Level1);



        Debug.Log(data.P_mon_nameKor);
        Debug.Log(pdata.P_player_HP);
        //Debug.Log(StaticClass.Add);
        //Debug.Log(StaticClass.ADD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
