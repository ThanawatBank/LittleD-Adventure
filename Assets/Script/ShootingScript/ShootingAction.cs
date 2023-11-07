using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private SoundLibary soundLibary;
    [SerializeField] private float cooldown;
    float lastshoot;
    public void Action()
    {
        action?.Invoke();
        AudioSource.PlayClipAtPoint(soundLibary.enemydieSound, transform.position);
    }
    
}
