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
    public float litterCount;
    private float spawnedCount;
    public float maxCount = 70f;
    private AIBase dropItem;
    private Inventory inv;

    public int dropped;

    public Slider meter;
    public Image fillMeter;
    public Gradient gradient;

    public GameObject NPC_00;
    public TextMeshProUGUI litterPercentage;

    public MapGenerator mapGenerator;

    private void Start()
    {
        //dropItem = GetComponent<AIBase>();

    }

    // Update is called once per frame
    void Update()
    {
        dropped = GetNPCDroppedCount();


        UpdateLitterMeter();
        dropItem = NPC_00.GetComponent<AIBase>();
        spawner = this.GetComponent<SpawnItems>();
        if (dropItem != null && spawner != null)
        {
            litterCount = (float)spawner.numberOfItems + dropped;//NPC_00.GetComponent<AIBase>().droppedCount;
            Debug.Log(spawner.numberOfItems + " : " + dropItem.droppedCount);
            UpdateLitterMeter();
            litterPercentage.text = meter.value.ToString() + "%";
            Debug.Log("no null reference");
            Debug.Log("Littercount = " + litterCount);
        }
        else 
        { 
            Debug.Log("dropItem is null"); 
        }
    }


    void UpdateLitterMeter() 
    {
        GameObject player = GameObject.FindWithTag("Player");
        inv = player.GetComponent<Inventory>();
        if (inv.itemAmount == inv.itemAmount + 1)
        {
            litterCount -= 1f;
            Debug.Log("Littercount = " + litterCount);
        }

        meter.value = (litterCount / maxCount) * 100f;
        if (meter.value >= maxCount) 
        {
            litterPercentage.color = Color.red;
        }
        else 
        {
            litterPercentage.color = Color.white;
        }
        //litterPercentage.text = meter.value.ToString() + "%";
        fillMeter.color = gradient.Evaluate(meter.normalizedValue);
    }


    int GetNPCDroppedCount()
    {

        int c = 0;

        for (int i = 0; i < mapGenerator.npcs.Count; i++)
        {
            c = c + mapGenerator.npcs[i].GetComponent<AIBase>().droppedCount;
        }

        Debug.Log(c);
        return c;
    }

}
