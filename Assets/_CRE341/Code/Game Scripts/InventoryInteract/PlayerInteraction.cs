using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    private Inventory inventory;

    private AudioClip pickupSound;
    private AudioClip emptySound;
    public AudioSource audioSource;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
        pickupSound = (AudioClip)Resources.Load("SFX_Pop_Bottle_Glass_Tiny_1");
        emptySound = (AudioClip)Resources.Load("SFX_Pop_Bottle_Big_1");
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null && inventory.inventoryFull == false)
        {
            currentInteractable.Interact();
            inventory.AddItem();
            Debug.Log("Picked Up Litter");
            //inventory.EmptyInventory();
            audioSource.clip = pickupSound; 
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && currentInteractable != null)
        {
            inventory.EmptyInventory();
            audioSource.clip = emptySound;
            audioSource.Play();
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
