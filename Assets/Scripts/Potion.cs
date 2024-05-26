using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerHealth playerHealth;
    [SerializeField] private int healthIncrease;
    [SerializeField] private int manaIncrease;

    private void Start()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            if (gameObject.CompareTag("mana"))
            {
                playerShoot.ManaRegen(manaIncrease, gameObject);
            }

            else if (gameObject.CompareTag("health"))
            {
                playerHealth.Heal(healthIncrease, gameObject);
            }
        }
    }


}
