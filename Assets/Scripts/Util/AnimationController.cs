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

    //선택한 클립의 총 길이를 알려준다.
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

    //현재 애니메이터에 설정되어 있는 클립들의 배열을 받아온다.
    public AnimationClip[] GetAnimationClips()
    {
        return m_clips;
    }

    //재생속도를 설정한다.
    public void SetPlaySpeed(float PlaySpeed)
    {
        if (animator.speed != PlaySpeed)
            animator.speed = PlaySpeed;
    }

    //현재 애니메이션이 재생되고 있는 속도를 받아온다.
    public float GetPlaySpeed()
    {
        return animator.speed;
    }

    //재생 정지
    public void Stop()
    {
        animator.StopPlayback();
    }

    //재생 일시정지
    public void Pause(float pausetime)
    {
        animator.speed = 0;
        //animator.CrossFade()
    }

    //다시 재생
    public void resume()
    {
        animator.speed = 1.0f;
    }

    //클립이름, 재생속도 (기본이 1배속), 재생 시간 (재생시간이 0이면 계속 반복), 블렌딩 시간(다음 동작으로 넘어가는데 걸릴 시간) 
    public void Play(string pname, float PlaySpeed=1.0f, float PlayTime=0,float blendingtime = 0.1f)
    {
        
        if (pname == currentplayclipname)
        {
            //Debug.Log("재생중인거 재생");
            return;
        }
        SetPlaySpeed(PlaySpeed);

        currentplayclipname = pname;
        animator.CrossFade(pname, blendingtime);
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

    //public void Play(string pname, int layer, float normalizedTime)
    //{
        
    //    if (pname == currentplayclipname)
    //    {
    //        //Debug.Log("재생중인거 재생");
    //        return;
    //    }
    //    currentplayclipname = pname;
    //    animator.CrossFade(pname, 0.3f, layer, normalizedTime);
    //}

    //현재 재생중인 클립인지 확인한다.
    public bool IsNowPlaying(string pname)
    {
        return (currentplayclipname == pname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
