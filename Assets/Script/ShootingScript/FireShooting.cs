using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooting : MonoBehaviour
{
    [SerializeField] private float speedFire;
    [SerializeField] private SoundLibary soundLibary;


    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * speedFire * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            return;
        }
        if (collision.GetComponent<ShootingAction>())
        {
            collision.GetComponent<ShootingAction>().Action();
            
        }
        if (collision.tag == "Enemy")
        {

            Destroy(gameObject);
            

        }
        if (collision.tag == "Wall")
        {

            Destroy(gameObject);

        }
        if (collision.tag == "Floor")
        {

            Destroy(gameObject);

        }

    }
}
