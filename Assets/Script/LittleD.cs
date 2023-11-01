using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleD : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private  float speed = 2;
    [SerializeField] private float jumpPower = 200;
    [SerializeField] private LayerMask groundLayer;
    

    Rigidbody2D rg2d;
    Animator animator;
    const float groundCheckRadius = 0.8f;
    float horizontalValue;
    float runSpeedModidifier = 2;
    [SerializeField] bool isGround = false;
    bool jump = false;
    
    bool isRuning = false;
    bool facingRight = true;

    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
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
            animator.SetBool("Jump",true);
            jump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        animator.SetFloat("yVelocity", rg2d.velocity.y);
        
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue,  jump);
    }

    void GroundCheck()
    {
        isGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0 )
        {
            isGround = true;
        }
        animator.SetBool("Jump",!isGround );
    }
    void Move(float dir,bool jumpFlag)
    {
        #region Jump


        if (isGround && jumpFlag)
        {
            isGround = false;
            jumpFlag = false;
            rg2d.AddForce(new Vector2(0f, jumpPower));
        }
        #endregion

        #region MoveandRun
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        if (isRuning)
        {
            xVal *= runSpeedModidifier;
        }
        Vector2 targetVelocity = new Vector2(xVal, rg2d.velocity.y);
        rg2d.velocity = targetVelocity;

        

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1,1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        animator.SetFloat("xVelocity",Mathf.Abs(rg2d.velocity.x));
        #endregion
    }
}
