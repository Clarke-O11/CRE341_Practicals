using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LitterMeter : MonoBehaviour
{
    private SpawnItems spawner;
    public int litterCount;
    public int spawnedCount;
    public float maxCount = 70f;
    private AIBase dropItem;
    private Inventory inv;
    public int totalCollectedItems = 0; // Track total collected items, not just current inventory

    public int dropped;

    public Slider meter;
    public Image fillMeter;
    public Gradient gradient;

    public GameObject NPC_00;
    public TextMeshProUGUI litterPercentage;

    public MapGenerator mapGenerator;
    
    private int previousInventoryCount = 0;

    private void Start()
    {
        spawner = GetComponent<SpawnItems>();
        if (spawner != null)
        {
            spawnedCount = spawner.numberOfItems;
        }
            
    }

    void Update()
    {
        // Get references once
        if (dropItem == null && NPC_00 != null)
            dropItem = NPC_00.GetComponent<AIBase>();
            
        if (spawner == null)
            spawner = GetComponent<SpawnItems>();
            
        // Track inventory changes to detect collections
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            inv = player.GetComponent<Inventory>();
            if (inv != null)
            {
                // If inventory decreased (items were deposited in bin)
                if (previousInventoryCount > inv.itemAmount)
                {
                    // No need to change total collected - they're still collected
                    // They're just in the bin now instead of inventory
                }
                // If inventory increased (new item picked up)
                else if (previousInventoryCount < inv.itemAmount)
                {
                    totalCollectedItems += (inv.itemAmount - previousInventoryCount);
                }
                
                previousInventoryCount = inv.itemAmount;
            }
        }
        
        // Update dropped count
        dropped = GetNPCDroppedCount();
        
        // Calculate total litter in the world
        if (spawner != null)
        {
            litterCount = spawner.numberOfItems + dropped - totalCollectedItems;
            
            // Update UI
            UpdateLitterMeter();
            litterPercentage.text = meter.value.ToString("F0") + "%";
        }
    }

    void UpdateLitterMeter()
    {
        // Update meter based on calculated litter count
        meter.value = Mathf.Clamp((litterCount / maxCount) * 100f, 0f, 100f);
        
        // Update colors
        if (meter.value >= maxCount)
        {
            litterPercentage.color = Color.red;
        }
        else
        {
            litterPercentage.color = Color.white;
        }
        
        fillMeter.color = gradient.Evaluate(meter.normalizedValue);
    }

    int GetNPCDroppedCount()
    {
        int c = 0;
        
        if (mapGenerator != null && mapGenerator.npcs != null)
        {
            for (int i = 0; i < mapGenerator.npcs.Count; i++)
            {
                if (mapGenerator.npcs[i] != null)
                {
                    AIBase aiBase = mapGenerator.npcs[i].GetComponent<AIBase>();
                    if (aiBase != null)
                        c += aiBase.droppedCount;
                }
            }
        }
        
        return c;
    }
}