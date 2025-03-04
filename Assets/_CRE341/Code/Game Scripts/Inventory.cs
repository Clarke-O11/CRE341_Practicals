using NUnit.Framework;
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
        itemMax = pickUpItems.maxItems;
        itemAmountDisplay.text = itemAmount.ToString();
        if (itemAmount == itemMax)
        {
            itemAmountDisplay.color = Color.red;
        }
        else
        { 
            itemAmountDisplay.color = Color.white;
        }
    }


}
