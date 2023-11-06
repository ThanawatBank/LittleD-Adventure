using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private SoundLibary soundLibary;

    public void Action()
    {
        action?.Invoke();
        AudioSource.PlayClipAtPoint(soundLibary.enemydieSound, transform.position);
    }
}
