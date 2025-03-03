using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public Item item;
    public Transform itemContent;
    public GameObject inventoryItem;
    private PickUpItems pickUpItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ListItems()
    {
        foreach (var item in pickUpItems.items) 
        { 
            GameObject obj = Instantiate(inventoryItem, itemContent);
        }
    }

}
