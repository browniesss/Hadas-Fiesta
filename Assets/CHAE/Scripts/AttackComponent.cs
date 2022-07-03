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


    

    public CAnimationComponent animator;


    public int AttackCount;


    private void Awake()
    {

        
        colliders = GetComponentsInChildren<Collider>();
        B_AttackOn = false;
        NextAttack = false;

        AttackCount = 0;

    }
    void Start()
    {
        animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackOn();
            
        }
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
            //AnimationManager.Instance.Play(animator, "_Attack02");
            //animator.SetInt($"{EnumTypes.eAnimationState.Attack}Num", 0);
            //animator.SetBool(EnumTypes.eAnimationState.Attack, true);
            
            //AttackCount++;
        }
        
    }    
        
    public void AttackEnd(int num)
    {
        if (animator == null)
        {
            Debug.Log("이거 실행");
            animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom) as CAnimationComponent;
        }

        Debug.Log("공격 끝");
        //animator.SetBool(EnumTypes.eAnimationState.Idle, true);
        //animator.SetBool(EnumTypes.eAnimationState.Attack, false);

        foreach (Collider coll in colliders)
        {
            if (coll.name == "weapon03")
            coll.enabled = false;
        }
       
        B_AttackOn = false;
        
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
