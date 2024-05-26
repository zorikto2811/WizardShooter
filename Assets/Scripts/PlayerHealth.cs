using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    private int currentHealth;
    public int CurrentHealth { get; private set; }
    [SerializeField] private UnityEvent dead;

    private void Start()
    {
        CurrentHealth = StartHealth;
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            dead.Invoke();
        }
    }

    public void Heal(int Increase, GameObject potion)
    {
        if (CurrentHealth < 100)
        {
            CurrentHealth += Increase;

            if (CurrentHealth > 100)
            {
                CurrentHealth = 100;
            }
            Destroy(potion);
        }
    }
}
