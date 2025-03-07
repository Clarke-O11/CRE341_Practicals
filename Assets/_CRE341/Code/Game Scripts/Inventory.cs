using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //private string itemName;
    private int itemAmount;
    private int itemMax;
    //public Image itemIcon;

    public TextMeshProUGUI itemAmountDisplay;

    private List<Item> items;

    public SpawnItems itemSpawner;       //litter
    //public GameObject specialItemPrefab;      //special NPC items
    public Transform player;
    public Transform itemT;

    public float pickUpRange;

    bool canPickup = true;

    public int numberOfItems;     //number of litter picked up
    public int maxItems = 10;     //max litter player can hold

    public GameObject spawnerObject;
    public List<GameObject> itemInv = new List<GameObject>();

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickUpLayer;

    public GameObject itemPrefab;

    // Update is called once per frame
    void Update()
    {
        InventoryDisplay();

        if (numberOfItems > maxItems) 
        {
            numberOfItems = maxItems;    
        }
    }

    void InventoryDisplay() 
    {
        itemAmount = numberOfItems;
        itemMax = maxItems;
        itemAmountDisplay.text = itemAmount.ToString();
        if (itemAmount >= itemMax)
        {
            itemAmountDisplay.color = Color.red;
        }
        else
        { 
            itemAmountDisplay.color = Color.white;
        }
    }

    public void AddItem() 
    { 
        if(canPickup == true) 
        { 
            numberOfItems = numberOfItems + 1;
            Debug.Log(gameObject.name + " detected");
            Console.WriteLine($"Added: {itemPrefab} to inventory"); 
        }
         
    }

    public void EmptyInventory() 
    {
        if (numberOfItems <= maxItems) 
        {
            numberOfItems = 0;
            canPickup = false;
        }
    }

}
