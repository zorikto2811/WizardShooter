using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float hor;
    private bool isJump;
    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        isJump = Input.GetButtonDown("Jump");
        if (isJump)
        {
            playerMove.Jump();
        }
    }

    private void FixedUpdate()
    {
        playerMove.HorizontalMove(hor);
    }
}
