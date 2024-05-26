using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private float startTime;
    [SerializeField] private Animator animator;
    private DestroyBarrier destroyBarrier;
    private ScoreCounter scoreCounter;
    private Enemy enemy;
    private float deathTimer;
    private bool hasEnemyDeath;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        deathTimer = startTime;
        scoreCounter = FindObjectOfType<ScoreCounter>();
        destroyBarrier = FindObjectOfType<DestroyBarrier>();
    }

    private void Update()
    {
        healthBar.value = enemy.CurrentHealth;
        if(hasEnemyDeath)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer <= 0)
            {
                scoreCounter.Score += 1;
                Destroy(gameObject);
            }
        }
    }

    public void EnemyDeath()
    {
        animator.SetTrigger("isDead");
        healthBar.gameObject.SetActive(false);
        hasEnemyDeath = true;
        if (gameObject.name == "Boss")
        {
            destroyBarrier.DestroyObstacle();
        }
    }
}
