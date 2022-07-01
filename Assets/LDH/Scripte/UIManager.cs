using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Canvas> canvas;
    private static UIManager instance = null;
    public enum CANVAS_NUM
    {
        ex_skill = 0,
        ex_Icon,
        sdf
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static UIManager Instance
    {
        get
        {
            if(instance==null)
            {
                return null;
            }
            return instance;
        }
       
    }
    public GameObject Prefabsload(string name , CANVAS_NUM x)
    {
        GameObject obj=new GameObject();
        if (GameObject.Find(name))
        {
            Debug.Log("찾음");
            return GameObject.Find(name);
        }
        else
        {
             obj = Resources.Load<GameObject>("Prefabs/" + name);
            Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity, canvas[(int)x].transform);
            Debug.Log("생성");
        }
        return obj;
    }
    public void EnableUI(string name)
    {
        if(GameObject.Find(name))
        {
            GameObject a = GameObject.Find(name);
            a.SetActive(false);
        }    
    }
    public void FirstView(string name)
    {
        if(GameObject.Find(name))
        {
            GameObject a = GameObject.Find(name);
            a.transform.SetAsFirstSibling();
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
