using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseComponent : MonoBehaviour
{
    [SerializeField]
    EnumTypes.eComponentTypes comtype;

    public EnumTypes.eComponentTypes p_comtype
    {
        get
        {
            return comtype;
        }
        set
        {
            comtype = value;
        }
    }
    public abstract void InitComtype();

    public abstract BaseComponent GetComponent();
    //public abstract void SetComponent();

    //public abstract void InitComponent();
}
