using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [Range(0, 200), SerializeField] private float speed;
    [Range(100, 500), SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private LayerMask ground;
    private Rigidbody2D rb;
    private float rayDistance = 24;
    private bool isGrounded;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, ground);
        animator.SetFloat("YPos", rb.velocity.y);
        animator.SetBool("isJumping", !isGrounded);
    }

    public void HorizontalMove(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Run", Mathf.Abs(horizontal));
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
