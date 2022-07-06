using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo
{
    public GameObject obj;
    public string path;
    public bool active = false;
    public bool Instance = false;
}
public class UIManager : Singleton<UIManager>
{
    private UIInfo uiinfo = new UIInfo();

    public List<UIInfo> info = new List<UIInfo>();
    public List<Canvas> canvas;


    public enum CANVAS_NUM
    {
        ex_skill = 0,
        ex_Icon,
        sdf
    }

    public void Prefabsload(string name, CANVAS_NUM x)
    {
        bool same = false;
        if (info.Count == 0)
        {
           
            GameObject obj = Resources.Load<GameObject>("Prefabs/" + name); //로드. 
            uiinfo.obj = Instantiate(obj);
            uiinfo.obj.transform.SetParent(canvas[(int)x].transform);
            uiinfo.path = name;
            uiinfo.obj.name = name;
            
            info.Add(uiinfo);
        }
        for (int i = 0; i < info.Count; i++)
        {
            //      Debug.Log(info[i].path);
            if (info[i].path == name)
            {
                same = true;
            }
        }
        if (same)
        {
            Debug.Log("이미있습니다");
        }
        else
        {
            GameObject obj = Resources.Load<GameObject>("Prefabs/" + name);
            UIInfo tmp = new UIInfo();
            tmp.obj = Instantiate(obj);
            tmp.obj.transform.SetParent(canvas[(int)x].transform);
            tmp.path = name;
            tmp.obj.name = name;
            info.Add(tmp);
          
        }

        //    return obj;

    }
    public void Show(string path)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path)
            {
                Debug.Log(info[i].path);
                info[i].obj.SetActive(true);
                // info[i].active = false;
            }
        }
    }
    public void Hide(string path)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (info[i].path == path)
            {
                Debug.Log(info[i].path);
                info[i].obj.SetActive(false);
                // info[i].active = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
