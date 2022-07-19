using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//애니메이션 이벤트들을 관리
//애니메이션 이벤트에 해당 함수들 OnBeginEventString, OnMidEventString, OnEndEventString 을 등록해주고
//각 이벤트들의 대리자에 실행하고자 하는 함수를 AddEvent(beginCallback begin, midCallback mid, endCallback end) 함수를 이용해 연결시켜주면 이벤트가 실행되면 해당 함수가 실행됨

public class AnimationEventSystem : MonoBehaviour
{
	AnimationController animator;

	public AnimationClip[] clips;
	//public AnimationEvent[][] eventlist;
	public List<AnimationEvent[]> eventlist = new List<AnimationEvent[]>();

	public Dictionary<string, AnimationEvent[]> eventdic = new Dictionary<string, AnimationEvent[]>();



	public delegate void beginCallback(string s_val);
	public delegate void midCallback(string s_val);
	public delegate void endCallback(string s_val);

	public beginCallback _beginCallback;
	public midCallback _midCallback;
	public endCallback _endCallback;

	public UnityEvent beginCallBack;
	public UnityAction begi;

	private void Awake()
    {

    }

    private void Start()
    {
		animator = GetComponent<AnimationController>();
		clips = animator.GetAnimationClips();
	}

    //애니메이션이벤트에 함수를 등록 하려면 해당 이벤트를 가지고 있는 애니메이션클립의 이름을 같이 넣어 준다.
    public void AddEvent(beginCallback begin, midCallback mid, endCallback end)
    {
		if(begin != null)
			_beginCallback += begin;
		if (mid != null)
			_midCallback += mid;
		if (end != null)
			_endCallback += end;
    }

	//Animation Event
	public void OnBeginEventString(string s_val)
	{
		//if (null != _beginCallback)
		//	_beginCallback();

		_beginCallback?.Invoke(s_val);
		
	}

	public void OnMidEventString(string s_val)
	{
		_midCallback?.Invoke(s_val);
	}

	public void OnEndEventString(string s_val)
	{
		_endCallback?.Invoke(s_val);
	}

}

