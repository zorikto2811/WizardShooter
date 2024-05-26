using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float startTime;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject deathBanner;
    private PlayerHealth playerHealth;
    private float deathTimer;
    private bool hasDeath;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        deathTimer = startTime;
    }

    private void Update()
    {
        healthBar.value = playerHealth.CurrentHealth;
        if (hasDeath )
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                deathBanner.SetActive(true);
                Time.timeScale = 0f;
                Destroy(gameObject);
            }
        }
    }

    public void Death()
    {
        animator.SetTrigger("isDead");
        healthBar.gameObject.SetActive(false);
        hasDeath = true;
    }
    }


