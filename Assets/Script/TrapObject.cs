using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TrapObject : MonoBehaviour
{
    [SerializeField] private GameObject vfx;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            FindObjectOfType<HealthBar>().Lostlife();
            VFXV();
        }
    }
    void VFXV()
    {
        Instantiate(vfx, transform.position, transform.rotation);
    }

}
