using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionSystem : MonoBehaviour
{

    [SerializeField] private Transform detectPoint;
    private const float detectRaduis = 0.2f;
    [SerializeField] private LayerMask detectLayer;

    [SerializeField] private GameObject detectObJect;
    [Header("Others")]
    [SerializeField] private List<GameObject> pickedItem = new List<GameObject>();
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
                detectObJect.GetComponent<Item>().Interact();
            }
        }
        
    }
    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
        
    }
    bool DetectObject()
    {
       Collider2D obj = Physics2D.OverlapCircle(detectPoint.position,detectRaduis,detectLayer);
        if (obj == null)
        {
            detectObJect = null;
            return false;
        }
        else
        {
            detectObJect = obj.gameObject;
            return true;
        }
    }
   public void PickUpItem(GameObject Item)
    {
        pickedItem.Add(Item);
    }
}
