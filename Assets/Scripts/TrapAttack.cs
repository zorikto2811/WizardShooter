using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private float attackInterval;
    [SerializeField] private Animator animator;
    [SerializeField] private int damage;
    [SerializeField] private Vector3 direction;
    private float attackTimer;

    private void Start()
    {
        attackTimer = attackInterval;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Invoke("Attack", 0.5f);
            animator.SetBool("Attack", true);
            attackTimer = attackInterval;
        }
        else
        {
            animator.SetBool("Attack", false);
        }

    }

    private void Attack()
    { 
        Vector2 endPos = transform.position + direction * attackRange;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(transform.position, endPos, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            { 
                    hit.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                    attackTimer = attackInterval;
            }
        }
    }
}
