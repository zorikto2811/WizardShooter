using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyObject : Health
{
    private int currentHealth;
    public int CurrentHealth { get; private set; }
    [SerializeField] private UnityEvent brokeObject;

    private void Start()
    {
        CurrentHealth = StartHealth;
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0)
            brokeObject.Invoke();
    }
}
