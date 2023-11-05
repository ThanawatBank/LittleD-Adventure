using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            LittleD player = GameObject.FindObjectOfType<LittleD>();
            player.Addscore();
            
        }
    }
}
