using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    Interactable currentItem;
    [SerializeField]
    KeyCode interactButton;
    [SerializeField] KeyCode altInteractButton;
    [SerializeField]
    int playerID;
    bool currentlyInteracting;
    [SerializeField]
    LayerMask interactableLayer;
    [SerializeField]
    GameObject alert;

    private void Start()
    {
        alert.SetActive(false);
    }
    private void Update()
    {
        if((Input.GetKeyDown(interactButton) || Input.GetKeyDown(altInteractButton)) && currentItem != null && !currentItem.hold && !currentItem.coolDown)
        {
            
            currentItem.Interact();
            
           
            
            
        }
        if ((Input.GetKey(interactButton) || Input.GetKey(altInteractButton)) && currentItem != null && currentItem.hold && !currentItem.coolDown)
        {
            if(currentItem.currentPlayer == 0)
            {
                currentItem.Interacting();
                currentlyInteracting = true;
                currentItem.currentPlayer = playerID;
            } else if(currentItem.currentPlayer == playerID)
            {
                currentItem.Interacting();
                currentlyInteracting = true;
            }
                //The item can be held by holding the interact button (or continuously interacted with)
               
        }
        //THIS MIGHT NOT BE NEEDED
        if((Input.GetKeyUp(interactButton) || Input.GetKeyUp(altInteractButton)) && currentItem != null)
        {
            currentItem.EndInteraction();
           
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Interactable>(out Interactable item) && !currentlyInteracting)
        {
          // print("Found " + collision.name);
            currentItem = item;
            alert.GetComponent<Alert>().SetTarget(item.transform);
            alert.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Interactable>(out Interactable item))
        {
            if(item == currentItem)
            {
                // currentItem.EndInteraction();
                StopTheInteraction();
            }
        }
    }

    public void StopTheInteraction()
    {
        currentItem.currentPlayer = 0;
        currentItem = null;
        currentlyInteracting = false;
        alert.SetActive(false);
    }
}
