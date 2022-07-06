using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillInformation : Information
{
    [SerializeField]
    private string mon_Index;
    [SerializeField]
    private string skill_Name_Kor;
    [SerializeField]
    private string skill_Name_En;
    [SerializeField]
    private int skill_ID;
    [SerializeField]
    private int skill_Type;
    [SerializeField]
    private int skill_Targetyp;

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
