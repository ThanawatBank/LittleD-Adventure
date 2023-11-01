using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1,10)]
    [SerializeField] private float smoothFactor;


    private void Start()
    {
        smoothFactor = 2.0f;
    }
    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetposition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetposition,smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition ;
    }
}
