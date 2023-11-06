using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    public void Action()
    {
        action?.Invoke();
    }
}
