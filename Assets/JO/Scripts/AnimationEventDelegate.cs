using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventDelegate : MonoBehaviour
{
    public delegate void AnimationEvent(string name);

    public AnimationEvent animationevent;

    public Dictionary<string, AnimationEvent> eventdic = new Dictionary<string, AnimationEvent>();

    public void AddEvent(AnimationEvent _event)
    {
        animationevent += _event;
    }

    public void ExecuteEvent(string name)
    {
        animationevent(name);
    }

}
