using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public List<State> Trans_List; // 전이 리스트
    public abstract bool Judge(out State _State, Battle_Character b_c);

    public abstract void Run(Battle_Character b_c);
}