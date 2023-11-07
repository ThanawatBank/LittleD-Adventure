using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] life;
    [SerializeField] private int livesRemaining;
    [SerializeField] private SoundLibary soundLibary;

    public void Lostlife()
    {
        if (livesRemaining == 0)
        {
            return;
        }
        livesRemaining--;
        life[livesRemaining].enabled = false;
        if (livesRemaining == 0)
        {
            FindObjectOfType<LittleD>().Die();
        }
        AudioSource.PlayClipAtPoint(soundLibary.Playerhit, transform.position);
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Lostlife();
            
        }
    }
}
