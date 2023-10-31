using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleD : MonoBehaviour
{
    [SerializeField] private  float speed = 1;

    Rigidbody2D rg2d;
    float horizontalValue;
    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        Move(horizontalValue);
    }
    void Move(float dir)
    {
        float xVal = dir * speed * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rg2d.velocity.y);
        rg2d.velocity = targetVelocity;
    }
}
