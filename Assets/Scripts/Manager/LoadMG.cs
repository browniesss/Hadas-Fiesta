using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//캐릭터  스탯증가.
//스킬 
//액션 -


public class LoadMG : MonoBehaviour
{
    [SerializeField]
     List<Battle_Character> MonsterLIst;

     void Awake()
    {
        //몬스터 저장할 리스트
        MonsterLIst = new List<Battle_Character>();
        //캐릭터 생성
        Battle_Character Player = new Battle_Character();

        //몬스터 생성 후 리스트에 저장 일단 8마리...
        for(int i=0; i < StaticClass.MonsterCount; i++)
        {
            Battle_Character Monster = new Battle_Character();
            MonsterLIst.Add(Monster);
        }
    }

    [SerializeField]
     MonsterInformation data;
    [SerializeField]
    DataLoad_Save TestDataLoad;
    //캐릭터,몬스터,오브젝트등 초기화,리스트 추가 시키기
    void ObjectInIt()
    {
        EnumScp.MonsterIndex tempindex = 0;

        //몬스터랑 캐릭터 스탯 디비로 받아와서 초기화 해주기.

        
        foreach(var monster in MonsterLIst)
        {
            //디비 받아오기
            data = ScriptableObject.CreateInstance<MonsterInformation>();
            data = TestDataLoad.TestScp(tempindex);
            tempindex++;
            //혹시 몬스터 넘어가면 초기화
            if(tempindex<=EnumScp.MonsterIndex.Max)
            {
                break;
            }
            //스텟 초기화 작업 (아직 안만들어짐) 함수 가져다 쓰기

            Debug.Log(data.P_mon_nameKor);
        }
    }

    //리소스들 로드 시키기
    void ResourceInit()
    {

    }



    void Start()
    {
        ObjectInIt();
      //  ResourceInit();
    }

    void Update()
    {
        
    }
}

