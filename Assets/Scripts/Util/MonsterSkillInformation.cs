using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSkill Data", menuName = "Scriptable Object/MonsterSkill Data", order = int.MaxValue)]
public class MonsterSkillInformation : ScriptableObject
{
    [SerializeField]
    private string mon_Index;
    public string P_mon_Index { get { return mon_Index; } set { mon_Index = value; } }
    [SerializeField]
    private string skill_Name_Kor;
    public string P_skill_Name_Kor { get { return skill_Name_Kor; } set { skill_Name_Kor = value; } }
    [SerializeField]
    private string skill_Name_En;
    public string P_skill_Name_En { get { return skill_Name_En; } set { skill_Name_En = value; } }
    [SerializeField]
    private int skill_ID;
    public int P_skill_ID { get { return skill_ID; } set { skill_ID = value; } }
    [SerializeField]
    private int skill_Type;
    public int P_skill_Type { get { return skill_Type; } set { skill_Type = value; } }
    [SerializeField]
    private int skill_Targetyp;
    public int P_skill_Targetyp { get { return skill_Targetyp; } set { skill_Targetyp = value; } }

    public void Set(string mon_index, string skill_name_kor, string skill_name_en, int skill_iD, int skill_type, int skill_targetyp)
    {
        
        mon_Index = mon_index;
        skill_Name_Kor = skill_name_kor;
        skill_Name_En = skill_name_en;
        skill_ID = skill_iD;
        skill_Type = skill_type;
        skill_Targetyp = skill_targetyp;
       
    }

}
