using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad_Save : MonoBehaviour
{
    [SerializeField]
    Dictionary<string, List<Information>> Dic_Data_Test = new Dictionary<string, List<Information>>();
    [SerializeField]
    List<CharacterInformation> test_list = new List<CharacterInformation>();

    public void Init()
    {

        List<Dictionary<string, object>> data_Dialog = LoadFile.Read("Test");


        for (int i = 0; i < data_Dialog.Count; i++)
        {
            CharacterInformation C_test = new CharacterInformation();
            C_test.set((int)data_Dialog[i]["hp"], (int)data_Dialog[i]["skillpoint"]);
            test_list.Add(C_test);


            Debug.Log(test_list[0].get());
        }



    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
