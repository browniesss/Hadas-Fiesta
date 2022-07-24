using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class AddressablesController : Singleton<AddressablesController>
{
	[SerializeField]
	private string _label;
	bool flag = true;
	[SerializeField]
//	private List<GameObject> _createdObjs { get; } = new List<GameObject>();
	private List<GameObject> _createdObjs = new List<GameObject>();
	GameObject tempob;
	int Loder_ListCount = 0;
	public bool load_Comp = false;

	private void Start()
	{

		//Instantiate("test1");
		//Instantiate("Monster");

		//Loder_ListCount = AddressablesLoader.ListCount;

		//temp_Show_list();
	}

	private async void Instantiate(string label)
	{
		
		await AddressablesLoader.InitAssets_label(label, _createdObjs);
		//setPos();

	
		//temp_Show_list();

	}

	public void testLoadAsset()
    {
		string name = "susu";
		 
        GameObject obj = find_Asset_in_list(name);

		if(obj==null)
        {
			StartCoroutine(AddressablesLoader.LoadGameObjectAndMaterial(name));
			Debug.Log("없어서 로드중..." );

            StartCoroutine(check_List_routine());

            if (load_Comp)
            {
                Debug.Log("load_Comp");

                obj = find_Asset_in_list(name);
                Debug.Log("load_Comp완료" + obj.name);
                Debug.Log("찾은 거" + obj.name);
                load_Comp = false;

            }
        }
        else
        {
            Debug.Log("찾은 거" + obj.name);
        }    
    }

    //리스트 기다렸다가 실행해주기 위함
    public IEnumerator check_List_routine()
    {
        yield return new WaitForSeconds(1.0f);

        Debug.Log("check_List_routine");
        if (Loder_ListCount != AddressablesLoader.tempobj.Count)
        {
            Loder_ListCount = AddressablesLoader.tempobj.Count;
            Debug.Log("list수는" + AddressablesLoader.tempobj.Count);
            check_List("susu");
            load_Comp = true;
        }
	}


	void temp_Show_list()
	{
		Debug.Log("이름보기");
		int c=0;

		foreach (var obj in _createdObjs)
		{
			c++;
			Debug.Log("생성네임"+obj.name);
		}
		Debug.Log(c);

	}

	void setPos()
	{
		foreach (var obj in _createdObjs)
		{
			obj.transform.position = new Vector3(0, 0, 0);
		
		}

	}

	//이름으로 썼으면 addAsset해주기
	public async void addAsset(string name)
	{
		await AddressablesLoader.InitAssets_name(name, _createdObjs);

	}

	void check_List(string name)
    {
		foreach (var obj in AddressablesLoader.tempobj)
		{
			if (name == obj.name)
			{
				Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
				Debug.Log(obj.name + "리스트안에 있음");
			}

		}
	}



    private void Update()
    {
		//if(Loder_ListCount!=AddressablesLoader.tempobj.Count)
  //      {
		//	Loder_ListCount = AddressablesLoader.tempobj.Count;
		//	Debug.Log("list수는" + AddressablesLoader.tempobj.Count);
		//	check_List("susu");
		//	load_Comp = true;
		//}


		//if(_createdObjs!=null)
		//      {
		//	foreach (var obj in _createdObjs)
		//	{
		//		Debug.Log("생성네임" + obj.name);
		//	}
		//}

	}

	//내가 올린거에서 prefabsName 일치하는 프리팹 생성 반환.
	public GameObject AddClone(string prefabsName)
	{
		GameObject tempGameobj = null;

		foreach (var obj in AddressablesLoader.tempobj)
		{
			if (obj.name == prefabsName)
			{
				tempGameobj = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
				flag = false;
				break;
			}
		}
		return tempGameobj;
	}


    //이름으로 썼으면 addAsset해주기
    public async void LoadResource(string name)
    {
        await AddressablesLoader.InitAssets_name(name);
    }

    ////어드레서블 이름,프리팹이름
    //public async void LoadResource(string name, string prefab)
    //{
    //	await AddressablesLoader.InitAssets_name(name);
    //	tempob = AddClone(prefab);
    //}

    public  GameObject Get_LoadResource(string name,string prefabsname)
    {
		LoadResource(name);

		foreach (var obj in AddressablesLoader.tempobj)
        {
			//if (prefabsname == obj.name)
   //         {
			//	Debug.Log(obj.name + "로드해옴");

			//	return obj;
   //         }

			Debug.Log(obj.name);
		}
		Debug.Log("일치하는 프리팹 없음 null반환");
		return null;
	}


	public GameObject find_Asset_in_list(string name)
    {
		GameObject return_frefabs=null ;

		foreach(var obj in _createdObjs)
        {
            int i = 0;

            if (obj==null)
            {
                Debug.Log("tempobj의" + i + "null");
                i++;
                break;
            }
			Debug.Log("_createdObjs의"+i + 1 + "번째 요소=" + obj.name);
			i++;

			if(obj.name==name)
            {
				return_frefabs = obj;
				Debug.Log("_createdObjs에서" + return_frefabs.name+"반환");
				return return_frefabs;
			}
        }

		foreach (var obj in AddressablesLoader.tempobj)
		{
            int i = 0;
            if (obj == null)
            {
                Debug.Log("tempobj의"+i+"null");
                i++;
                break;
            }
          
			Debug.Log("tempobj의" + i+ 1 + "번째 요소=" + obj.name);
			i++;

			if (obj.name == name)
			{
				return_frefabs = obj;
				Debug.Log("tempobj에서" + return_frefabs.name + "반환");
				return return_frefabs;
			}
		}

		return return_frefabs;
	}

	//개수 리스트로 받아가기?  보류? ->풀링 하고나서ㄱㄱ
	//public GameObject AddClone<T>(string prefabsName,List<GameObject> saveCloneList)
	//{
	//	GameObject tempGameobj = null;

	//	foreach (var obj in AddressablesLoader.tempobj)
	//	{
	//		if (obj.name == prefabsName)
	//		{
	//			saveCloneList.Add(Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity));
	//			flag = false;
	//			break;
	//		}
	//	}
	//	return tempGameobj;
	//}


	//네임으로 생성할 때 예시...?
	void add()
	{

		foreach (var obj in AddressablesLoader.tempobj)
		{
			tempob = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
			flag = false;
		}
		//AddressablesLoader.tempobj.Clear();
	}


	//리스트로 삭제 할 때 예시..?
	public void tempdes()
	{
		foreach (var obj in AddressablesLoader.tempobj)
		{
			GameObject tem = obj;
			Destroy_Obj(ref tem, tempob);
			break;
		}
	}

	public GameObject LoadAsset(string name)
    {
		GameObject temp =AddressablesLoader.returnAssets(name);
		_createdObjs.Add(temp);
		return temp;
	}

	public void Destroy_Obj(ref GameObject deleteMemory, GameObject deleteobj)  //메모리 해제 할 오브젝트,삭제할 오브젝트.
	{
		if (!Addressables.ReleaseInstance(deleteMemory))
		{
			Destroy(deleteobj);
			Addressables.ReleaseInstance(deleteMemory);
			AddressablesLoader.tempobj.Remove(deleteMemory);
			Debug.Log("객체 메모리 삭제");
		}
	}

	//주의점 -> 메모리 해제 하시기 전에 메모리를 사용하는 오브젝트들을 전부 destroy 하고 함수 호출해주세요!
	public void Destroy_Obj(ref GameObject deleteMemory)  //메모리 해제 할 오브젝트.
	{
		if (!Addressables.ReleaseInstance(deleteMemory))
		{
			Addressables.ReleaseInstance(deleteMemory);
			AddressablesLoader.tempobj.Remove(deleteMemory);
			Debug.Log("메모리 삭제");
		}
	}
	//레이블 삭제
	public void Destroy_Obj(GameObject obj)  //삭제할 오브젝트
	{
		if (!Addressables.ReleaseInstance(obj))
		{
			Addressables.ReleaseInstance(obj);
			Destroy(obj);
			_createdObjs.Remove(obj);
		}
	}

}