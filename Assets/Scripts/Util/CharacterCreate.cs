using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : Singleton<CharacterCreate>
{

    //  public DataLoad_Save TestDataLoad;



    void Start()
    {
        DataLoad_Save.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateMonster(EnumScp.MonsterIndex p_index, Transform trans)
    {
        Vector3 q = new Vector3(7, 0, 0);
        MonsterInformation data = ScriptableObject.CreateInstance<MonsterInformation>();
        data = DataLoad_Save.Instance.Get_MonsterDB(p_index);

        GameObject a = Resources.Load<GameObject>(StaticClass.Prefabs + "Skeleton_Knight");
     //   a.transform.position = trans.position;
        a.GetComponent<Battle_Character>().Stat_Initialize(data);
        // trans.position = q;

        GameObject b = Instantiate(a, trans);
        EnemyHpbar.Instance.SetHpBar(data.P_mon_MaxHP, b.transform);
        b.GetComponent<Battle_Character>().MyHpbar = EnemyHpbar.Instance.MyHpbar;

    }

}
