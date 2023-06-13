using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayAnimationWithTransition playerAnim;


    [SerializeField]
    private float moveSpeed = 5f, jumpForce = 19f;

    private Rigidbody2D mybody;

    private Transform groundCheckPos;

    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayAnimationWithTransition>();

        groundCheckPos = transform.GetChild(0).transform;
    }

    private void Update()
    { 
        PlayerJump();
        AnimatePlayer(); 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, 0.02f, groundLayer);
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown(TagManager.JUMP_BUTTON))
        {
            if(IsGrounded())
            {
                mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }


    void AnimatePlayer()
    {
        playerAnim.PlayJump(mybody.velocity.y);
        playerAnim.PlayFromJumpToRunning(IsGrounded());
    }
}
