using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy_Enum
{
    public enum Enemy_Grade
    {
        Normal = 1, // 일반 몬스터 
        General,  // 정예 몬스터
        Boss // 보스 몬스터
    }

    public enum Enemy_Type
    {
        Preemptive = 1, // 선공형
        Non_Preemptive,  // 비선공형
    }

    public enum Enemy_Attack_Type
    {
        Skill_1_sel,
        Skill_2_sel,
        Skill_3_sel,
        Normal_Attack,
    }

    public enum Enemy_Attack_Logic
    {
        Melee_Attack = 0,
        Long_Attack,
        Attack_Logic_Amount,
    }
}