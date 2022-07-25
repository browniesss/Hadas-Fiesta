using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{
    [SerializeField]
    List<BaseComponent> AttackComList = new List<BaseComponent>();

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    //public void AttackMove(string clipname)
    //{

    //    for (int i = 0; i < attackinfos.Length; i++)
    //    {
    //        if (attackinfos[i].aniclip.name == clipname)
    //        {
    //            movecom.FowardDoMove(attackinfos[i].movedis, attackinfos[i].movetime);

    //            return;
    //        }
    //    }

    //    for (int i = 0; i < skillinfos.Length; i++)
    //    {
    //        if (skillinfos[i].aniclip.name == clipname)
    //        {
    //            movecom.FowardDoMove(skillinfos[i].Movedis, skillinfos[i].MoveTime);
    //            return;
    //        }
    //    }

    //}
    //public void AttackEnd(string s_val)
    //{
    //    if (effectobj != null)
    //    {
    //        Debug.Log($"dasdw공격 끝 들어옴 -> {s_val}");
    //        effectobj.transform.parent = preparent;
    //    }


    //    if (curval.IsAttacking == true)
    //        curval.IsAttacking = false;

    //    lastAttackTime = Time.time;
    //}

    public void AddComponent(BaseComponent com , string keyname)
    {
        //임시
        AttackComList.Add(com);
    }

    
    public void EventAdd(int size , string clipname , string methodname , AnimationEventSystem eventsystem)
    {
        
    }
         

    public void ComboAttackMana(AnimationController animator  , string AniName , float time)
    {
        animator.Play(AniName, time);
    }
    public void AttackMana(AnimationController animator, string AniName, float time)
    {
        animator.Play(AniName, time);
    }


    public Transform CreateEffect(GameObject effect , Transform EffectPosRot , float destroyTime)
    {
        GameObject effectobj;
        Transform temp = EffectPosRot;


        effectobj = GameObject.Instantiate(effect);

        


        effectobj.transform.position = EffectPosRot.position;
        effectobj.transform.rotation = EffectPosRot.rotation;
        effectobj.transform.parent = this.transform;
        
        //Destroy(effectobj, destroyTime);

        //StartCoroutine(Cor_TimeCounter(tempPos));

        return effectobj.transform.parent;
    }


    IEnumerator Cor_TimeCounter(Vector3 time)
    {
       

        
        yield return new WaitForSeconds(3f);
        Debug.Log(time);

    }
}
