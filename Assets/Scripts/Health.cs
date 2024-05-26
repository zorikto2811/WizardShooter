using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Health : MonoBehaviour
{
    private int startHealth;
    [field: SerializeField] public int StartHealth { get; set; }

    public abstract void TakeDamage(int damage);
}
