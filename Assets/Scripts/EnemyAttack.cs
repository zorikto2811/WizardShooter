using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAttack : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private Transform player;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float agroRange;
    [SerializeField] private float intervalBetweenAttacks;
    private float attackTimer;
    [SerializeField, Range(30, 35)] private float attackDis;
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Animator animator;
    [SerializeField] private int damage;
    private bool isAgro = false;
    private bool isSearching = false;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        attackTimer = intervalBetweenAttacks;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
        }

        else
        {
            if (isAgro)
            {
                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChase", 3);
                }
            }
        }

        if (isAgro)
        {
            Chase();
        }

        Attack(attackDis);
    }

    private void Chase()
    {
        if (isFacingRight)
        {
            enemyRb.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRb.velocity = new Vector2(-speed, 0);
        }
        animator.SetBool("isWalking", true);
    }

    private void StopChase()
    {
        isAgro = false;
        isSearching = false;
        enemyRb.velocity = new Vector2(0, 0);
        animator.SetBool("isWalking", false);
    }

    private bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;
        if (transform.position.x < player.position.x)
        {
            castDist = -distance;
            isFacingRight = true;
            enemySprite.flipX = false;
        }
        else
        {
            enemySprite.flipX = true;
            isFacingRight = false;
        }
        Vector2 endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castPoint.position, endPos, Color.magenta);
        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.cyan);
        }
        return val;
    }

    private void Attack(float attackDis)
    {
        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackDis, 1 << LayerMask.NameToLayer("Player"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                animator.SetBool("Attack", true);
                StopChase();
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0)
                {
                    hit.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                    attackTimer = intervalBetweenAttacks;
                }
                Debug.DrawLine(transform.position, direction * attackDis, Color.red);
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            Debug.DrawLine(transform.position, direction, Color.green);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
            Debug.Log("Collision!");
        StopChase();
    }
}
