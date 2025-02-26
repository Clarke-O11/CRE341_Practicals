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
    [SerializeField] List<GameObject> items = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        numberOfItems = items.Count;

        //Check if player is in raneg and if 'E' is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && numberOfItems < maxItems) 
        {
            PickUp();
        }

        if (numberOfItems == maxItems) 
        { 
            //Empty items into bin
            
        }

        // Inventory UI Display
        //itemDisplay.text = numberOfItems.ToString() + itemImage;
    }

    private void PickUp() 
    {
        items.Add(itemSpawner.itemPrefab);
        itemSpawner.items.Remove(itemSpawner.itemPrefab);
    }
}
