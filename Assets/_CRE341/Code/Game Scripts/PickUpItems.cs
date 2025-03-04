using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public SpawnItems itemSpawner;       //litter
    //public GameObject specialItemPrefab;      //special NPC items
    public Transform player;

    public float pickUpRange;

    public int numberOfItems;     //number of litter picked up
    public int maxItems = 10;     //max litter player can hold

    public GameObject spawnerObject;
    public List<GameObject> itemInv = new List<GameObject>();

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickUpLayer;

    // Update is called once per frame
    void Update()
    {
        numberOfItems = itemInv.Count;

        //Check if player is in raneg and if 'E' is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && numberOfItems < maxItems) 
        {
            PickUp();
        }

        /*if (numberOfItems == maxItems) 
        { 
            //Empty items into bin
            //Check if player is at a bin
            
        }*/

        // Inventory UI Display
        //itemDisplay.text = numberOfItems.ToString() + itemImage;
    }

    private void PickUp() 
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit raycastHit, pickUpRange)) 
        {
            itemInv.Add(itemSpawner.itemPrefab);
            itemSpawner.items.Remove(itemSpawner.itemPrefab);
            Debug.Log(gameObject.name + " detected");
        }
    }
}
