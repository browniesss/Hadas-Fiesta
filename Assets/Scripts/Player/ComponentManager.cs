using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 객체와 객체의 하위에 있는 모든 캐릭터관련 컴포넌트들을 종합해서 등록하고 관리한다.
//각각의 등록된 컴포넌트들은 서로간 데이터를 주고받을때 컴포넌트 매니저를 통해서 주고받는다.
//public class ComponentManager : MonoBehaviour
//{
//    static ComponentManager _CMInstance;
//    public static ComponentManager GetI
//    {
//        get
//        {
//            return _CMInstance;
//        }
//    }



//    [SerializeField]
//    BaseComponent[] comlist = new BaseComponent[(int)EnumTypes.eComponentTypes.comMax];

//    private void Awake()
//    {
//        _CMInstance = this;
        

//    }


//    private void Start()
//    {
//        BaseComponent[] temp = GetComponentsInChildren<BaseComponent>();

//        foreach (BaseComponent a in temp)
//        {
//            comlist[(int)a.p_comtype] = a;
//        }
//    }

//    public BaseComponent GetMyComponent(EnumTypes.eComponentTypes type)
//    {
//        return comlist[(int)type];
//    }

//    public void InActiveMyComponent(EnumTypes.eComponentTypes type)
//    {
//        comlist[(int)type].enabled = false;
//    }

//    public void ActiveMyComponent(EnumTypes.eComponentTypes type)
//    {
//        comlist[(int)type].enabled = true;
//    }

//    //public void AddComponent()
//    //{

//    //}

//    //public void DeleteComponent()
//    //{

//    //}




//}
