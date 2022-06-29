using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class AnimationInfos
{
    Animator animator;
    int m_clipsnum;
    AnimationClip[] m_clips;
    Dictionary<string, AnimatorControllerParameter> m_floatParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_IntParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_BoolParamDic = new Dictionary<string, AnimatorControllerParameter>();
    Dictionary<string, AnimatorControllerParameter> m_TriggerParamDic = new Dictionary<string, AnimatorControllerParameter>();


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
            //Debug.Log($"{i}번, {param[i].name}, {param[i].type}");
        }

        AnimatorController anicontrol = animator.runtimeAnimatorController as AnimatorController;
        if (anicontrol == null)
            Debug.Log("Is Null!");
        m_clips = animator.runtimeAnimatorController.animationClips;
    }


    public AnimatorControllerParameter[] GetFloatParams()
    {
        AnimatorControllerParameter[] temp = new AnimatorControllerParameter[m_floatParamDic.Count];
        int i = 0;
        foreach(KeyValuePair<string, AnimatorControllerParameter> item in m_floatParamDic)
        {
            temp[i++] = item.Value;
        }
        return temp;
    }

    public AnimatorControllerParameter[] GetIntParams()
    {
        AnimatorControllerParameter[] temp = new AnimatorControllerParameter[m_IntParamDic.Count];
        int i = 0;
        foreach (KeyValuePair<string, AnimatorControllerParameter> item in m_IntParamDic)
        {
            temp[i++] = item.Value;
        }
        return temp;
    }

    public AnimatorControllerParameter[] GetBoolParams()
    {
        AnimatorControllerParameter[] temp = new AnimatorControllerParameter[m_BoolParamDic.Count];
        int i = 0;
        foreach (KeyValuePair<string, AnimatorControllerParameter> item in m_BoolParamDic)
        {
            temp[i++] = item.Value;
        }
        return temp;
    }

    public AnimatorControllerParameter[] GetTriggerParams()
    {
        AnimatorControllerParameter[] temp = new AnimatorControllerParameter[m_TriggerParamDic.Count];
        int i = 0;
        foreach (KeyValuePair<string, AnimatorControllerParameter> item in m_TriggerParamDic)
        {
            temp[i++] = item.Value;
        }
        return temp;
    }

    public AnimationClip[] GetAnimationClips()
    {
        return m_clips;
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

    public void Play(string pname)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(pname))
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
            
        animator.Play(pname);
    }

    public void Play(string pname, int layer, float normalizedTime)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(pname))
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
        animator.Play(pname, layer, normalizedTime);
    }
}
