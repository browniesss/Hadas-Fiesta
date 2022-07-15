using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class AddressablesController : MonoBehaviour
{
	[SerializeField]
	private string _label;
	bool flag = true;
	[SerializeField]
//	private List<GameObject> _createdObjs { get; } = new List<GameObject>();
	private List<GameObject> _createdObjs = new List<GameObject>();


	private void Start()
	{

		//Instantiate("test1");
		Instantiate("Monster");

		temp_Show_list();
	}

	private async void Instantiate(string label)
	{
		
		await AddressablesLoader.InitAssets_label(label, _createdObjs);
		//setPos();

	
		//temp_Show_list();

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

    private void Update()
    {
		//if(_createdObjs!=null)
  //      {
		//	foreach (var obj in _createdObjs)
		//	{
		//		Debug.Log("생성네임" + obj.name);
		//	}
		//}
		
	}

    void add()
	{
		foreach (var obj in AddressablesLoader.tempobj)
		{
			Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
		}
		AddressablesLoader.tempobj.Clear();
		flag = false;
	}

	public void tempdes()
	{
		//foreach (var obj in _createdObjs)
		//{
		//	Destroy_Obj(obj);
		//}

		Destroy_Obj(_createdObjs[0]); 

	}


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