using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{

    [SerializeField]
    private int AttackAnimationNum;


    [SerializeField]
    public Collider[] colliders;    

    public bool B_AttackOn;


    public Animator ani;

    public CAnimationComponent animator;

    public AnimationClip aaa;
    void Start()
    {
        animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom);
        
        colliders = GetComponentsInChildren<Collider>();

        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
            Debug.Log(coll.name);
            Debug.Log(coll.gameObject.name);
        }

        //foreach (var item in animator.Attackclips)
        //{
        //    Debug.Log(item.name);
        //}

        //ani.GetCurrentAnimatorStateInfo(0)


        aaa = animator.clips[EnumTypes.eAnimationState.Attack][(int)EnumTypes.eAniAttack.Attack02];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!B_AttackOn)
            {
                B_AttackOn = true;
                Debug.Log("공격");
                AttackOn();

                foreach (Collider coll in colliders)
                {
                    coll.enabled = true;
                }
            }
        }
    }
    public void AttackOn()
    {
        
        if (animator == null)
        {
            Debug.Log("이거 실행");
            animator = (CAnimationComponent)ComponentManager.GetI.GetMyComponent(EnumTypes.eComponentTypes.AnimatorCom);
        }
       

        animator.SetBool(EnumTypes.eAnimationState.Attack, true);
    }    
        
    public void AttackEnd(int num)
    {

        Debug.Log("공격 끝");
        animator.SetBool(EnumTypes.eAnimationState.Idle, true);


        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
        }

        B_AttackOn = false;
    }

    IEnumerator Anitime()
    {
        
        yield return null;


    }
   
}
