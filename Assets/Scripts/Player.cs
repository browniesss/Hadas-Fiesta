using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    Rigidbody player_Rigidbody;

    void Start()
    {
        player_Rigidbody = GetComponent<Rigidbody>();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(h, 0, v) * Time.deltaTime * moveSpeed;
    }

    void Update()
    {
        Move();
    }
}
