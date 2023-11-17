using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LittleD : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed = 2;
    [SerializeField] private float jumpPower = 7;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int totalJump;
    private int availableJump;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SoundLibary soundLibary;



    private Rigidbody2D rg2d;
    private Animator animator;
    private const float groundCheckRadius = 0.8f;
    private float horizontalValue;
    private float runSpeedModidifier = 2;
    [SerializeField] bool isGround = false;
    

    private bool mutipleJump;
    private bool isRuning = false;
    private bool facingRight = true;
    private bool coyoteJump;
    private bool isdead = false;
   

    private void Awake()
    {
        availableJump = totalJump;
        rg2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (isdead) return;

        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRuning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRuning = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }

        animator.SetFloat("yVelocity", rg2d.velocity.y);

    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue);
    }
    void Jump()
    {


        if (isGround)
        {
            mutipleJump = true;
            availableJump--;
            rg2d.velocity = Vector2.up * jumpPower;
            animator.SetBool("Jump", true);
            AudioSource.PlayClipAtPoint(soundLibary.soundJump, transform.position);
        }
        else //กระโดด2ครั้ง
        {
            if (coyoteJump)
            {
                mutipleJump = true;
                availableJump--;
                rg2d.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
                AudioSource.PlayClipAtPoint(soundLibary.soundJump, transform.position);
            }

            if (mutipleJump && availableJump > 0)
            {
                availableJump--;
                rg2d.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
                AudioSource.PlayClipAtPoint(soundLibary.soundJump, transform.position);
            }
        }


    }
    private IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        coyoteJump = false;
    }
    void GroundCheck()
    {
        bool wasGround = isGround;
        isGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGround = true;
            if (!wasGround)
            {
                availableJump = totalJump;
                mutipleJump = false;
            }

            foreach (var c in colliders)
            {
                if (c.tag == "MovingPlatForm")
                {
                    transform.parent = c.transform;
                }
            }

        }
        else
        {
            transform.parent = null;

            if (wasGround)
            {
                StartCoroutine(CoyoteJumpDelay());
            }
        }
        animator.SetBool("Jump", !isGround);
    }
    void Move(float dir)
    {


        #region MoveandRun
        float xVal = dir * speed * 50 * Time.fixedDeltaTime;
        if (isRuning)
        {
            xVal *= runSpeedModidifier;
        }
        Vector2 targetVelocity = new Vector2(xVal, rg2d.velocity.y);
        rg2d.velocity = targetVelocity;



        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rg2d.velocity.x));
        #endregion
    }

    public void Die()
    {
        isdead = true;
        FindObjectOfType<LevelManager>().Restart();
        ResetScore();
    }
    bool CanMove()
    {
        bool can = true;

        if (isdead)
        {
            can = false;
        }
        return can;
    }

    public void Addscore()
    {
        playerData.score = playerData.score + 1;


    }
    public int GetScore()
    {
        return playerData.score;

    }
    public void ResetScore()
    {
        playerData.score = 0;
    }
    
    

}
