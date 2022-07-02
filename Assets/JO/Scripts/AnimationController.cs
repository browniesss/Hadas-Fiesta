using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public int m_clipsnum;
    public AnimationClip[] m_clips;

    public string currentplayclipname;



    // Start is called before the first frame update
    void Start()
    {

        if(!TryGetComponent<Animator>(out animator))
        {
            gameObject.AddComponent<Animator>();
        }

        AnimatorController anicontrol = animator.runtimeAnimatorController as AnimatorController;
        if (anicontrol == null)
            Debug.Log("Is Null!");
        m_clips = animator.runtimeAnimatorController.animationClips;
    }


    public float GetClipLength(string pname)
    {
        float time = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        foreach (var a in ac.animationClips)
        {
            if (a.name == pname)
            {
                time = a.length;
            }
        }
        return time;
    }

    public AnimationClip[] GetAnimationClips()
    {
        return m_clips;
    }

    public void SetPlaySpeed(float PlaySpeed)
    {
        if (animator.speed != PlaySpeed)
            animator.speed = PlaySpeed;
    }

    public float GetPlaySpeed()
    {
        return animator.speed;
    }

    

    

    public void Stop()
    {
        animator.StopPlayback();
    }

    public void Pause(float pausetime)
    {
        animator.speed = 0;
        //animator.CrossFade()
    }

    public void resume()
    {
        animator.speed = 1.0f;
    }

    public void Play(string pname)
    {
        if(pname == currentplayclipname)
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
        
        currentplayclipname = pname;
        animator.CrossFade(pname, 0.3f);
        //StartCoroutine(CountTime(pname, 0.1f));
        //animator.Play(pname);
    }

    public void Play(string pname, float PlaySpeed, float PlayTime)
    {
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName(pname))
        //{
        //    //Debug.Log("재생중인거 재생");
        //    return;
        //}
        if (pname == currentplayclipname)
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
        SetPlaySpeed(PlaySpeed);

        currentplayclipname = pname;
        animator.CrossFade(pname, 0.3f);
    }

    public IEnumerator CountTime(string playname, float desttime)
    {
        float starttime = Time.time;
        Debug.Log($"코루틴 들어옴");
        while (true)
        {
            if (Time.time - starttime >= desttime)
            {
                Debug.Log($"{playname} 애니메이션 실행함");
                animator.Play(playname);
                yield break;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }

    }

    public void Play(string pname, int layer, float normalizedTime)
    {
        //if (animator.GetCurrentAnimatorStateInfo(0).IsName(pname))
        //{
        //    //Debug.Log("재생중인거 재생");
        //    return;
        //}
        if (pname == currentplayclipname)
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
        currentplayclipname = pname;
        animator.CrossFade(pname, 0.3f, layer, normalizedTime);
    }




    public bool IsNowPlaying(string pname)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(pname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
