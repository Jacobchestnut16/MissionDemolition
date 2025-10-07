using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        Projectile proj = other.GetComponent<Projectile>();
        if (proj != null)
        {
            goalMet = true;
            Material projMat = GetComponent<Renderer>().material;
            Color color = projMat.color;
            color.a = 0.75f;
            projMat.color = color;
        }
    }
}
