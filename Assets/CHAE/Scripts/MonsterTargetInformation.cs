using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTargetInformation : Information
{
    [SerializeField]
    private int Target_Rank;
    [SerializeField]
    private int Number;
    [SerializeField]
    private int Character_ID;
    [SerializeField]
    private Vector3 target_Location;
    [SerializeField]
    private Vector3 mon_Location;
    [SerializeField]
    private int mon_Range;
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
