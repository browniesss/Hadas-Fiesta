using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventDelegate : MonoBehaviour
{
	System.Action _beginCallback = null;
	System.Action _midCallback = null;
	System.Action _endCallback = null;

	public void Play(string trigger,
		System.Action beginCallback = null,
		System.Action midCallback = null,
		System.Action endCallback = null
		)
	{
		GetComponent<Animator>().SetTrigger(trigger);
		_beginCallback = beginCallback;
		_midCallback = midCallback;
		_endCallback = endCallback;
	}

	//Animation Event
	public void OnBeginEvent()
	{
		//if (null != _beginCallback)
		//	_beginCallback();

		_beginCallback?.Invoke();   //위 주석부분처럼 작성해도 무관합니다.
	}

	public void OnMidEvent()
	{
		_midCallback?.Invoke();
	}

	public void OnEndEvent()
	{
		Debug.Log("Animaton End Event");
		_endCallback?.Invoke();
	}
}
