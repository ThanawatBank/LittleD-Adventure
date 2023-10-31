using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleD : MonoBehaviour
{
    [SerializeField] private  float speed = 1;

    Rigidbody2D rg2d;
    Animator animator;
    float horizontalValue;
    float runSpeedModidifier = 2;
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
       else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRuning = false;
        }

    }
    private void FixedUpdate()
    {
        Move(horizontalValue);
    }
    void Move(float dir)
    {
        float xVal = dir * speed * 100 * Time.deltaTime;
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
    }
}
