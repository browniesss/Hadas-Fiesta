using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AddressablesLoader
{
	public static List<GameObject> tempobj = new List<GameObject>();

	//레이블로 생성
	//Addressables.Release();
	public static async Task InitAssets_label<T>(string label, List<T> createdObjs)
		where T : Object
	{
		Debug.Log("생성전" + label);


		var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
		Debug.Log("생성가ㅣ져옴" + label);


		foreach (var location in locations)
		{
			createdObjs.Add(await Addressables.InstantiateAsync(location).Task as T);
			Debug.Log("생성" + label);
		}
	}

	//이름으로 생성
	//Addressables.ReleaseInstance();
	public static async Task InitAssets_name<T>(string object_name, List<T> createdObjs)
		where T : Object
	{
		//AsyncOperationHandle<GameObject> operationHandle=
		// Addressables.LoadAssetAsync<GameObject>(object_name);

		Addressables.LoadAssetAsync<GameObject>(object_name).Completed += ObjectLoadDone;

		// yield return operationHandle;

		//createdObjs.Add(operationHandle.Result as T);

	}
	//이름으로 생성
	//리스트 필요없이 메모리 할당만 할 때
	//Addressables.ReleaseInstance();
	public static async Task InitAssets_name(string object_name)
	{
		//AsyncOperationHandle<GameObject> operationHandle=
		// Addressables.LoadAssetAsync<GameObject>(object_name);

		Addressables.LoadAssetAsync<GameObject>(object_name).Completed += ObjectLoadDone;

		// yield return operationHandle;

		//createdObjs.Add(operationHandle.Result as T
	}

	private static void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
	{
		GameObject gameObject = obj.Result;
		tempobj.Add(gameObject);

		Debug.Log("생성");

	}

}
