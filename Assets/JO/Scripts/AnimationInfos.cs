using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInfos
{
    Animator animator;
    int m_clipsnum;
    AnimationClip[] m_clips;
    Dictionary<string, AnimatorControllerParameter> m_floatParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_IntParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_BoolParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_TriggerParamDic = new Dictionary<string, AnimatorControllerParameter>();

    List<AnimatorControllerParameter> m_floatParamList;
    List<AnimatorControllerParameter> m_IntParamList;
    List<AnimatorControllerParameter> m_BoolParamList;
    List<AnimatorControllerParameter> m_TriggerParamList;
    AnimatorControllerParameter[] m_FloatParams;
    AnimatorControllerParameter[] m_IntParams;
    AnimatorControllerParameter[] m_BoolParams;
    AnimatorControllerParameter[] m_TriggerParams;

    public AnimationInfos(Animator animator)
    {
        this.animator = animator;
        AnimatorControllerParameter[] param = animator.parameters;
        for(int i=0;i<param.Length;i++)
        {
            if(param[i].type.ToString() == "int")
            {
                m_IntParamDic.Add(param[i].name, param[i]);
            }
            else if(param[i].type.ToString() == "float")
            {
                m_floatParamDic.Add(param[i].name, param[i]);
            }
            else if (param[i].type.ToString() == "bool")
            {
                m_BoolParamDic.Add(param[i].name, param[i]);
            }
            else
            {
                m_TriggerParamDic.Add(param[i].name, param[i]);
            }
            //Debug.Log($"{i}¹ø, {param[i].name}, {param[i].type}");
        }

    }

    public void Init(Animator animator)
    {

    }

    public void SetFloat(string pname, float value)
    {
        animator.SetFloat(pname, value);
    }

    public void SetInt(string pname, int value)
    {
        animator.SetInteger(pname, value);
    }

    public void SetBool(string pname, bool value)
    {
        animator.SetBool(pname, value);
    }

    public void SetTrigger(string pname)
    {
        animator.SetTrigger(pname);
    }
    public void SetPlaySpeed(float rate)
    {
        animator.speed = rate;
    }
}
