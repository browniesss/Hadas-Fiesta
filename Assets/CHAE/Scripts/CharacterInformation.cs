using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : Information
{
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int SkillPoint;
    
    public void set(int h , int skill)
    {
        Hp = h;
        SkillPoint = skill;
    }

    public int get()
    {
        return Hp;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
