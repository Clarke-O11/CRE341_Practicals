using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //private string itemName;
    public int itemAmount;
    private int itemMax;
    //public Image itemIcon;

    public TextMeshProUGUI itemAmountDisplay;

    private List<Item> items;

    public SpawnItems itemSpawner;       //litter

    public Transform player;
    public Transform itemT;

    public float pickUpRange;

    //bool canPickup = true;

    public int numberOfItems;     //number of litter picked up
    public int maxItems = 10;     //max litter player can hold

    public GameObject spawnerObject;
    public List<GameObject> itemInv = new List<GameObject>();

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask pickUpLayer;

    public GameObject itemPrefab;

    public bool hasRequiredItem;
    public bool inventoryFull = false;

    private ItemTypes item;

    // Update is called once per frame
    void Update()
    {
        InventoryDisplay();
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
        //if(inventoryFull == false && canPickup == true && gameObject.name == "Litter" || inventoryFull == false && canPickup == true && gameObject.name == "Litter_Drop")
        //{ 
        //    numberOfItems = numberOfItems + 1;
        //    itemInv.Add(itemPrefab);
        //    Debug.Log(numberOfItems);
        //    Debug.Log($"Added: {itemPrefab} to inventory");

        //    if (numberOfItems > maxItems)
        //    {
        //        numberOfItems = maxItems;
        //        inventoryFull = true;
        //    }
        //}
        if (inventoryFull == false && item == ItemTypes.Litter)
        {
            numberOfItems = numberOfItems + 1;
            //itemInv.Add(specialItemPrefab);
            ////Debug.Log(gameObject.name + " detected");
            //Console.WriteLine($"Added: {specialItemPrefab} to inventory");
            hasRequiredItem = true;
            Debug.Log(numberOfItems);
            Debug.Log($"Added: {itemPrefab} to inventory");

            if (numberOfItems > maxItems)
            {
                numberOfItems = maxItems;
                inventoryFull = true;
            }
        }

    }

    public void EmptyInventory() 
    {
        if (numberOfItems <= maxItems) 
        {
            numberOfItems = 0;
            //canPickup = false;
            inventoryFull = false;
        }
    }

}

public enum ItemTypes
{ 
    Litter
}
