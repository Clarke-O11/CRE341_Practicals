using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();      
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
            inventory.AddItem();
            //inventory.EmptyInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentInteractable != null)
        {
            inventory.EmptyInventory();
        }
    }

    void CheckInteraction() 
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")     //looking at interactable
            { 
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable) 
                {
                    currentInteractable.DisableOutline();
                }

                if (newInteractable.enabled) 
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else //if interactable not enabled
                {
                    DisableCurrentInteractable();
                }
            }
            else //if nothing is interactable
            {
                DisableCurrentInteractable();
            }
        }
        else //if nothing within reach
        { 
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable) 
    { 
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        UIController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()  
    {
        UIController.instance.DisableInteractionText();
        if (currentInteractable) 
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
