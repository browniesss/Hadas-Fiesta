using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataParsing : MonoBehaviour
{
    [SerializeField]
    Dictionary<string, List<Information>> Dic_Data_Test = new Dictionary<string, List<Information>>();

    List<int> test = new List<int>();
    List<int> test2 = new List<int>();
    public void Init()
    {

        List<Dictionary<string, object>> data_Dialog = LoadFile.Read("Test");

        
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            List<Information> test3 = new List<Information>();
            CharacterInformation C_test = new CharacterInformation();

            test.Add((int)data_Dialog[i]["hp"]);
            test2.Add((int)data_Dialog[i]["skillpoint"]);

            C_test.set(test[0], test2[0]);
            test3.Add(C_test);
            
            Dic_Data_Test.Add("Level1" , test3 );
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
