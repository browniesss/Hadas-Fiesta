using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCPTEST : MonoBehaviour
{

    //테스트용 몬스터 스크립트 

    public MonsterInformation data;   
    public DataLoad_Save TestDataLoad;


    

    void Start()
    {
        data = ScriptableObject.CreateInstance<MonsterInformation>();
        data = TestDataLoad.Get_MonsterDB(EnumScp.MonsterIndex.mon_02_01);  
        
        

        Debug.Log(data.P_mon_nameKor);

        //Debug.Log(StaticClass.Add);
        //Debug.Log(StaticClass.ADD);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
