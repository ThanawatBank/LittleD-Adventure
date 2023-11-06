using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    private enum InteractionType { NONE,PickUp,Examine,}
    [SerializeField]private InteractionType Type;
    [SerializeField] private SoundLibary soundLibary;

    [SerializeField] private UnityEvent customEvent;
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
                AudioSource.PlayClipAtPoint(soundLibary.gemSound, transform.position);
                break;
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;
           
            default:
                Debug.Log("Null Item");
                break;
        }
        customEvent.Invoke();
        

    }
   
    
}
