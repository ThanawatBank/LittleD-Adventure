using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [Range(1,10)]
    [SerializeField] private float smoothFactor;
    [SerializeField] private Vector3 maxValue, minValue;


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

        Vector3 boundPosition = new Vector3
            (Mathf.Clamp(targetposition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetposition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetposition.z, minValue.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition ;
    }
}
