using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform parenttransform;
    private void Update()
    {
        if(gameObject.transform.localPosition.sqrMagnitude>0)
        {
            parenttransform.position = this.gameObject.transform.position;
            this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
