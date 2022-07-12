using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Battle_Character>().ai.Return_Set();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 25f);
    }

    void Update()
    {

    }
}
