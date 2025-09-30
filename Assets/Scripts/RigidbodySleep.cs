using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Rigidbody) )]
public class RigidbodySleep : MonoBehaviour
{
    private Rigidbody   rigid;
    private int         sleepCount = 4;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (sleepCount > 0)
        {
            rigid.Sleep();
            sleepCount--;
        }
    }
}
