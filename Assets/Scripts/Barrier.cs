using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IDestroyableObject
{
    public float Healt = 30;

    public void TakeDamage(float damage)
    {
        Healt -= damage;
        if (Healt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
