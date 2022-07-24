using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameMG.Instance.Resource.Instantiate("susu");

    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
