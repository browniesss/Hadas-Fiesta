using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterTarget Data", menuName = "Scriptable Object/MonsterTarget Data", order = int.MaxValue)]
public class MonsterTargetInformation : ScriptableObject
{
    [SerializeField]
    private int Target_Rank;
    public int P_Target_Rank { get { return Target_Rank; } set { Target_Rank = value; } }
    [SerializeField]
    private int Number;
    public int P_Number { get { return Number; } set { Number = value; } }
    [SerializeField]
    private int Character_ID;
    public int P_Character_ID { get { return Character_ID; } set { Character_ID = value; } }
    [SerializeField]
    private Vector3 target_Location;
    public Vector3 P_target_Location { get { return target_Location; } set { target_Location = value; } }
    [SerializeField]
    private Vector3 mon_Location;
    public Vector3 P_mon_Location { get { return mon_Location; } set { mon_Location = value; } }
    [SerializeField]
    private int mon_Range;
    public int P_mon_Range { get { return mon_Range; } set { mon_Range = value; } }
    public void Set(int Target_Rank, int Number, int Character_ID, int target_Location, int target_Location2, int target_Location3, int mon_Location, int mon_Location2, int mon_Location3, int mon_Range)
    {

        this.Target_Rank = Target_Rank;
        this.Number = Number;
        this.Character_ID = Character_ID;
        this.target_Location = new Vector3(target_Location, target_Location2, target_Location3);
        this.mon_Location = new Vector3(mon_Location, mon_Location2, mon_Location3);
        this.mon_Range = mon_Range;

    }
    public Vector3 Get()
    {
        return target_Location;
    }
}
