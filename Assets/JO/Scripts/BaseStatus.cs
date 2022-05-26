using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus:MonoBehaviour
{
    [Header("=========================")]
    [Header("Status")]
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float curHP;
    [SerializeField]
    private float maxEnergy;
    [SerializeField]
    private float curEnergy;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float defense;
    


    public float MaxHP { get => maxHP; set => maxHP = value; }
    public float CurHP { get => curHP; set => curHP = value; }
    public float MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public float CurEnergy { get => curEnergy; set => curEnergy = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Defense { get => defense; set => defense = value; }
}
