using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//현재 씬에 존재하는 모든 animator를 받아와서 
//기능
//1. animator 파라미터 값 변경 해당animator컴포넌트 이름과 변경할 파라미터의 이름을 이용해서 

public class AnimationManager : Singleton<AnimationManager>
{
    public Dictionary<Animator, AnimationInfos> animatordic = new Dictionary<Animator, AnimationInfos>();

    public List<Animator> animatorlist;

    public Animator animator;

    public AnimatorControllerParameter[] _params;


    private void Awake()
    {
        animatorlist = GameObject.FindObjectsOfType<Animator>().ToList();
        int i = 0;
        foreach (var a in animatorlist)
        {
            
            animatordic.Add(a, new AnimationInfos(a));
            Debug.Log($"애니메이터 하나 받아옴 ID = {a.GetInstanceID()}");
            AnimatorControllerParameter anii;
            AnimationClip clip;
            //animator.
            
        }


        //for (int i = 0; i < _params.Length; i++)
        //{
        //    Debug.Log($"{i}번, {_params[i].name}, {_params[i].type}");
        //    //Debug.Log($"{_params[i].defaultBool}");
        //    //Debug.Log($"{_params[i].defaultFloat}");
        //    //Debug.Log($"{_params[i].defaultInt}");
        //}

    }


    public void SetInt(Animator id, string pname, int value)
    {
        animatordic[id].SetInt(pname, value);
    }

    public void SetBool(Animator id, string pname, bool value)
    {
        animatordic[id].SetBool(pname, value);
    }

    public void SetFloat(Animator id, string pname, float value)
    {
        animatordic[id].SetFloat(pname, value);
    }

    public void SetTrigger(Animator id, string pname)
    {
        animatordic[id].SetTrigger(pname);
    }

    public void SetPlaySpeed(Animator id, float rate)
    {
        Debug.Log($"속도 수정 {rate}");
        animatordic[id].SetPlaySpeed(rate);
    }

    public void Play(Animator id, string pname)
    {
        animatordic[id].Play(pname);
    }

    public void Play(Animator id, string pname,int layer, float normalizedTime)
    {
        animatordic[id].Play(pname, layer, normalizedTime);
    }


    private void Update()
    {
        
    }

}
