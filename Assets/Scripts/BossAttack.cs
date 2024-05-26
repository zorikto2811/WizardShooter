using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private float attackInterval;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform[] createPos;
    [SerializeField] private Transform player;
    [SerializeField] private Transform startCasting;
    [SerializeField] private Transform endCasting;
    [SerializeField] private GameObject[] creaturePrefabs;
    private float attackTimer;
    private int i = 0;

    private void Start()
    {
        attackTimer = attackInterval;
    }
    private void Update()
    {
        attackTimer -= Time.deltaTime;
        Attack();
    }

    private void Attack()
    {
        RaycastHit2D hit = Physics2D.Linecast(startCasting.position, endCasting.position, 1 << LayerMask.NameToLayer("Player"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                CreateMonsters();
                Debug.DrawLine(startCasting.position, endCasting.position, Color.red);
            }
            else
            {
                animator.SetBool("Attack", false);
            }
        }
        else
            animator.SetBool("Attack", false);
        Debug.DrawLine(startCasting.position, endCasting.position, Color.green);
    }

    private void CreateMonsters()
    {
        if (attackTimer < 0)
        {
            if (i < creaturePrefabs.Length)
            {
                Instantiate(creaturePrefabs[i], createPos[i].position, Quaternion.Euler(0f, 0f, 0f));
                animator.SetBool("Attack", true);
                attackTimer = attackInterval;
                i++;
            }
            if( i == creaturePrefabs.Length)
            {
                i= 0;
            }
        }
        else
            animator.SetBool("Attack", false);
    }
}
