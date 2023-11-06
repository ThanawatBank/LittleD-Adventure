using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject shootingItem;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private SoundLibary soundLibary;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
            AudioSource.PlayClipAtPoint(soundLibary.shootingSound, transform.position);
        }
    }

    private void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;

    }
}
