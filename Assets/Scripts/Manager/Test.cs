using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            UIManager.Instance.Prefabsload("Fire Demon-Yellow", UIManager.CANVAS_NUM.ex_skill);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            UIManager.Instance.Prefabsload("Test1", UIManager.CANVAS_NUM.ex_skill);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            UIManager.Instance.Prefabsload("Test2", UIManager.CANVAS_NUM.ex_skill);


        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            UIManager.Instance.Hide("Fire Demon-Yellow");

            UIManager.Instance.Hide("Test2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.Instance.Show("Fire Demon-Yellow");

            UIManager.Instance.Show("Test2");
        }
    }
}
