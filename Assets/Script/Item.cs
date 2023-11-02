using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    private enum InteractionType { NONE,PickUp,Examine}
    [SerializeField]private InteractionType Type;
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 8;
    }
    public void Interact()
    {
        switch (Type)
        {
            case InteractionType.PickUp:
                
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;
            default:
                Debug.Log("Null Item");
                break;
        }
    }
}
