using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed=10f;
    public bool eixst = false;
    private Vector3 direction;

    Rigidbody Rigidbody;

    public void Shooting_target(Vector3 target)
    {
        direction = (target - transform.position).normalized;

    }

    public void set_target(Vector3 target)
    {
        Rigidbody = GetComponent<Rigidbody>();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(eixst)
        {
            GetComponent<Rigidbody>().AddForce(direction * 10);
            //  GetComponent<Transform>().transform.Translate(direction * speed * Time.deltaTime);

        }
        if(gameObject.transform.position.y<=0)
        {
            Destroy(gameObject);
        }
    }
}
