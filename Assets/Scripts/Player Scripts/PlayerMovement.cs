using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayAnimationWithTransition playerAnim;

    private ScoreCounter scoreCounter;

    [SerializeField]
    private float moveSpeed = 5f, jumpForce = 19f;
    private float animSpeedThreshold = 0.02f, animSpeed = 0.15f, increaseSpeed_After = 20f;

    private Rigidbody2D mybody;

    private Transform groundCheckPos;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float attackWaitTime = 0.5f;

    private float attackTimer;
    private bool canAttack;

    private Animator animator;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayAnimationWithTransition>();

        scoreCounter = FindObjectOfType<ScoreCounter>();

        groundCheckPos = transform.GetChild(0).transform;

        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetFloat(TagManager.RUNSPEED_ANIMATION_PARAMETER, animSpeed);
    }

    private void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttackAction();

        if(scoreCounter.GetScore() > increaseSpeed_After)
        {
            moveSpeed += 0.2f;
            increaseSpeed_After += 20f;
            animSpeed += animSpeedThreshold;

            animator.SetFloat(TagManager.RUNSPEED_ANIMATION_PARAMETER, animSpeed);

            

            /*allClips = animator.runtimeAnimatorController.animationClips;

            foreach (AnimationClip clip in allClips)
            {
                if (clip == clipToControl)
                {
                    animator.SetFloat(clip.name, animSpeedThreshold);
                    animation_Run.clip = clip;
                    break;
                }
            }*/
        }
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
                SoundManager.instance.Play_PlayerJump_Sound();
                mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
        }
    }


    void AnimatePlayer()
    {
        playerAnim.PlayJump(mybody.velocity.y);
        playerAnim.PlayFromJumpToRunning(IsGrounded());
    }


    void GetAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.K)  && IsGrounded())
        {
            if (Time.time > attackTimer)
            {
                attackTimer = Time.time + attackWaitTime;
                canAttack = true;
            }
        }
    }

    void HandleAttackAction()
    {
        if (canAttack && IsGrounded())
        {
            canAttack = false;
            playerAnim.PlayAttack();
            SoundManager.instance.Play_PlayerAttack_Sound();
        }
    }
}
