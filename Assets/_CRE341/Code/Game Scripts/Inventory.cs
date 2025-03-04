using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //private string itemName;
    private int itemAmount;
    //public Image itemIcon;

    private PickUpItems pickUpItems;
    public TextMeshProUGUI itemAmountDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickUpItems = GetComponent<PickUpItems>();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryDisplay();
    }

    void InventoryDisplay() 
    {
        itemAmount = pickUpItems.numberOfItems;
        itemAmountDisplay.text = itemAmount.ToString();
        if (itemAmount == pickUpItems.maxItems) 
        { 
            itemAmountDisplay.color = Color.red;
        }
    }


}
