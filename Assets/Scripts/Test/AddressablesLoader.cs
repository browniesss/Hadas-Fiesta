using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public static class AddressablesLoader
{
    public static List<GameObject> tempobj = new List<GameObject>();
    public static int ListCount = 0;
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

    //   public static void InitAssets_name(string object_name)
    //{

    //	Addressables.LoadAssetAsync<GameObject>(object_name).Completed += ObjectLoadDone;

    //}

    //static IEnumerator LoadGameObjectAndMaterial(string name)
    //{
    //	//Load a GameObject
    //	AsyncOperationHandle<GameObject> goHandle = Addressables.LoadAssetAsync<GameObject>(name);
    //	yield return goHandle;
    //	if (goHandle.Status == AsyncOperationStatus.Succeeded)
    //	{
    //		GameObject obj = goHandle.Result;
    //		tempobj.Add(obj);
    //		//etc...
    //	}



    //	////Load a Material
    //	//AsyncOperationHandle<IList<IResourceLocation>> locationHandle = Addressables.LoadResourceLocationsAsync("materialKey");
    //	//yield return locationHandle;
    //	//AsyncOperationHandle<Material> matHandle = Addressables.LoadAssetAsync<Material>(locationHandle.Result[0]);
    //	//yield return matHandle;
    //	//if (matHandle.Status == AsyncOperationStatus.Succeeded)
    //	//{
    //	//	Material mat = matHandle.Result;
    //	//	//etc...
    //	//}

    //	//Use this only when the objects are no longer needed
    //	Addressables.Release(goHandle);
    //	//Addressables.Release(matHandle);
    //}

    //객체 불러오기
    public static IEnumerator LoadGameObjectAndMaterial(string name)
    {
        Debug.Log("LoadGameObjectAndMaterial호출");
        //Load a GameObject
        AsyncOperationHandle<GameObject> goHandle = Addressables.LoadAssetAsync<GameObject>(name);
        yield return goHandle;
        if (goHandle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObject = goHandle.Result;
            tempobj.Add(gameObject);
            ListCount=tempobj.Count;
            Debug.Log(gameObject.name + "로드");

            foreach (var obj in tempobj)
            {
                //	c++;
                Debug.Log(obj.name + "리스트확인");
            }
            //etc...
        }

        ////Load a Material
        //AsyncOperationHandle<IList<IResourceLocation>> locationHandle = Addressables.LoadResourceLocationsAsync("materialKey");
        //yield return locationHandle;
        //AsyncOperationHandle<Material> matHandle = Addressables.LoadAssetAsync<Material>(locationHandle.Result[0]);
        //yield return matHandle;
        //if (matHandle.Status == AsyncOperationStatus.Succeeded)
        //{
        //	Material mat = matHandle.Result;
        //	//etc...
        //}

        //Use this only when the objects are no longer needed
        //Addressables.Release(goHandle);
        //Addressables.Release(matHandle);
    }

    private static void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        GameObject gameObject = obj.Result;
        tempobj.Add(gameObject);

        Debug.Log(obj.Result.name + "어드레서블로드");

    }

    public static GameObject returnAssets(string object_name)
    {
        GameObject tempobj = null;

        Addressables.LoadAssetAsync<GameObject>(object_name).Completed += (handle) =>
         {
             tempobj = handle.Result;
             Debug.Log(tempobj.name + "에셋리턴");
         // return tempobj;
     };

        if (tempobj != null)
        {
            return tempobj;
        }
        Debug.Log("비어있음");
        return tempobj;
    }




    //public static GameObject LoadAsset_name(string object_name )
    //   {


    //	return 
    //   }


}
