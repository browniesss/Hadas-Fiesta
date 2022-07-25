using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*사용할 모든 클립들이 등록되어있는 animation controller 가 연결된 animator 가 필요
  GetAnimationClips()를 이용하여 현재 등록된 클립들을 받아오든지, 직접 입력하던지 해서 재생을 원하는 클립의 이름을 알아와서
  Play(클립이름, 재생속도, 재생시간, 블렌딩속도) 함수를 이용해 재생*/
public class AnimationController : MonoBehaviour
{
    //[Header("애니메이션들이 등록된 애니메이션 컨트롤러가 필요")]
    //public AnimatorController anicontrol;
    [Header("확인용")]
    public Animator animator;
    public int m_clipsnum;
    public AnimationClip[] m_clips;
    public string currentplayclipname;
    public float prespeed;
    public float currentSpeed;
    public float currnetPlayTime;
    public float currentBlending;
    public delegate void Invoker();

    
    private void Awake()
    {
        if (!TryGetComponent<Animator>(out animator))
        {
            animator = GetComponentInChildren<Animator>();
            if(animator==null)
            {
                Debug.Log($"{gameObject.name} animator component 없음!");
            }
        }

        m_clips = animator.runtimeAnimatorController.animationClips;
    }

    

    //클립이름, 재생속도 (기본이 1배속), 재생 시간 (재생시간이 0이면 계속 반복), 블렌딩 시간(다음 동작으로 넘어가는데 걸릴 시간) 
    public void Play(string pname, float PlaySpeed = 1.0f, float PlayTime = 0, float blendingtime = 0.1f,bool replay = false)
    {
        //해당 변수가 true면 이미 재생중인 클립을 다시 재상하는게 가능
        if(!replay)
        {
            if (pname == currentplayclipname)
            {
                return;
            }
        }

        if(PlayTime!=0)
        {
            StartCoroutine(Cor_TimeCounter(PlayTime, Stop));
        }

        SetPlaySpeed(PlaySpeed);

        currentplayclipname = pname;

        animator.CrossFade(pname, blendingtime);
    }

    ////클립이름, 재생속도 (기본이 1배속), 블렌딩 시간(다음 동작으로 넘어가는데 걸릴 시간) 
    //public void Play(string pname, float PlaySpeed = 1.0f, float blendingtime = 0.1f)
    //{

    //    if (pname == currentplayclipname)
    //    {
    //        return;
    //    }

    //    SetPlaySpeed(PlaySpeed);

    //    currentplayclipname = pname;
    //    animator.CrossFade(pname, blendingtime);
    //}


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
    public void Pause()
    {
        prespeed = animator.speed;
        animator.speed = 0;
        //animator.CrossFade()
    }

    //다시 재생
    public void Resume()
    {
        if(prespeed!=0)
            animator.speed = prespeed;
        else
            animator.speed = 1.0f;

        prespeed = 0;
    }

    

    //public IEnumerator CountTime(string playname, float desttime)
    //{
    //    float starttime = Time.time;
    //    Debug.Log($"코루틴 들어옴");
    //    while (true)
    //    {
    //        if (Time.time - starttime >= desttime)
    //        {
    //            Debug.Log($"{playname} 애니메이션 실행함");
    //            animator.Play(playname);
    //            yield break;
    //        }

    //        yield return new WaitForSeconds(Time.deltaTime);
    //    }

    //}


    //공격이 시작된지 일정 시간 뒤에 이펙트를 실행해야 할 때 사용
    IEnumerator Cor_TimeCounter(float time, Invoker invoker)
    {
        float starttime = Time.time;

        while (true)
        {
            if ((Time.time - starttime) >= time)
            {
                invoker.Invoke();
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
