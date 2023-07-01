using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayAnimationWithTransition playerAnim;

    private ScoreCounter scoreCounter;

    [SerializeField]
    private float moveSpeed = 5f, jumpForce = 19f, increaseSpeed_After = 10f;
    private float animSpeed = 0.01f, animSpeedThreshold = 0.15f;

    private Rigidbody2D mybody;

    private Transform groundCheckPos;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float attackWaitTime = 0.5f;

    private float attackTimer;
    private bool canAttack;

    private Animator animator;
    public AnimationClip clipToControl;
    private Animation animation_Run;

    [SerializeField]
    AnimationClip[] allClips;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayAnimationWithTransition>();

        scoreCounter = FindObjectOfType<ScoreCounter>();

        groundCheckPos = transform.GetChild(0).transform;

        animator = GetComponent<Animator>();

        animation_Run = GetComponent<Animation>();
    }

    private void Update()
    {
        PlayerJump();
        AnimatePlayer();
        GetAttackInput();
        HandleAttackAction();

        if(scoreCounter.GetScore() > increaseSpeed_After)
        {
            Debug.Log(animSpeedThreshold);
            moveSpeed += 0.2f;
            increaseSpeed_After += 5f;
            animSpeedThreshold += animSpeed;

            allClips = animator.runtimeAnimatorController.animationClips;

            foreach (AnimationClip clip in allClips)
            {
                if (clip == clipToControl)
                {
                    animator.SetFloat(clip.name, animSpeedThreshold);
                    animation_Run.clip = clip;
                    break;
                }
            }
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
