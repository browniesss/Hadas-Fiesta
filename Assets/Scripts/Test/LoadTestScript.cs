using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void cleic()
    {
        GameMG.Instance.Resource.Instantiate("Terrain");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
