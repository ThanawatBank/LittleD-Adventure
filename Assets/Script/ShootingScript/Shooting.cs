using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject shootingItem;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private SoundLibary soundLibary;
    [SerializeField] private float firerate;
    float nextfire;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
            
            
        }
        
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            GameObject si = Instantiate(shootingItem, shootingPoint);
            si.transform.parent = null;
            AudioSource.PlayClipAtPoint(soundLibary.shootingSound, transform.position);
        }
        

    }
}
