using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTestScript : MonoBehaviour
{

    public GameObject pos;
    public GameObject pos1;

    // Start is called before the first frame update
    void Start()
    {
        GameMG.Instance.Resource.Instantiate("Terrain", pos.transform);

        GameMG.Instance.Resource.Instantiate("PlayerCharacter", pos1.transform);

        // CharacterCreate.Instance.CreateMonster()
    }

    public void cleic()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
