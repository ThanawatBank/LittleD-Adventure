using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private SoundLibary soundLibary;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject vfx;
    private float lastshoot;
    public void Action()
    {
        action?.Invoke();
        VFX();
        AudioSource.PlayClipAtPoint(soundLibary.enemydieSound, transform.position);
    }
    void VFX()
    {
        Instantiate(vfx,transform.position,transform.rotation);
    }
    
}
