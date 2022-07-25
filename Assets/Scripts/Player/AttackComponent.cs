using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{

    [SerializeField]
    private int AttackAnimationNum;
    [SerializeField]
    public Collider[] colliders;
    [SerializeField]
    private bool NextAttack;

    public bool B_AttackOn;
    public AnimationController animator;
    public int AttackCount;
    public float AttackDelay;
    
    // public AttackMovementInfo[] attackinfos;
    private void Awake()
    {

        
        colliders = GetComponentsInChildren<Collider>();
        B_AttackOn = false;
        NextAttack = false;
        AttackDelay = 1.0f;
        AttackCount = 1;

    }
    void Start()
    {
        
        animator = GetComponentInChildren<AnimationController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackOn();
            
        }
    }

    IEnumerator Cor_NextAttackDelay()
    {
        NextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        NextAttack = false;
        B_AttackOn = false;
    }

    public void AttackOn()
    {
        if (!B_AttackOn)
        {
            B_AttackOn = true;
            Debug.Log("공격");
            foreach (Collider coll in colliders)
            {
                Debug.Log(coll.name);
                coll.enabled = true;
            }

            if (NextAttack)
            {
                animator.Play($"_Attack0{0}",AttackCount);
            }
            else
            {
                animator.Play("_Attack01");
            }
           
        }
        
    }    
        
    public void AttackEnd(int num)
    {
        if (animator == null)
        {
            Debug.Log("이거 실행");
            
        }

        Debug.Log("공격 끝");      

        foreach (Collider coll in colliders)
        {
            if (coll.name == "weapon03")
            coll.enabled = false;
        }
       
        
        animator.Play("_Idle");
        StartCoroutine(Cor_NextAttackDelay());
    }
    public void On_NextAttack()
    {
        NextAttack = true;
        
    }
    public void Off_NextAttack()
    {
        NextAttack = false;
    }
    IEnumerator Anitime()
    {
        
        yield return null;


    }
   
}
