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
}