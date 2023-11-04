using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] life;
    [SerializeField] private int livesRemaining;

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
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Lostlife();
        }
    }
}
