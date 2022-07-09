using System.Collections.Generic;
using UnityEngine;

public class AddressablesController : MonoBehaviour
{
	[SerializeField]
	private string _label;
	private Transform _parent;
	private List<GameObject> _createdObjs { get; } = new List<GameObject>();

	private void Start()
	{
		//_parent = GameObject.Find("SampleScene").transform;
		Instantiate();
	}

	private async void Instantiate()
	{
		Debug.Log("持失s");

		await AddressablesLoader.InitAssets(_label, _createdObjs, _parent);
		Debug.Log("持失");
		setPos();

	}

	void setPos()
	{
		foreach (var obj in _createdObjs)
		{
			obj.transform.position = new Vector3(0, 0, 0);

		}

	}

}