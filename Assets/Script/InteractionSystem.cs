using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionSystem : MonoBehaviour
{

    [SerializeField] private Transform detectPoint;
    private const float detectRaduis = 0.2f;
    [SerializeField] private LayerMask detectLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DetectObject())
        {
            if (InteractInput())
            {
                Debug.Log("Sphare");
            }
        }
        
    }
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
        
    }
    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectPoint.position,detectRaduis,detectLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detectPoint.position,detectRaduis);
    }
}
