using System;
using UnityEngine;

public class RNG_Drop : MonoBehaviour
{
    public GameObject itemDropped;
    public int dropChance;

    private Droppable droppable;

    private SpawnItems spawns;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ItemDropped();
    }

    void ItemDropped() 
    { 
        int randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        if (randomNumber <= dropChance) 
        {
            this.droppable.Drop();
            spawns.items.Add(itemDropped);
            Console.WriteLine($"{itemDropped} was dropped by NPC");
        }
    }
}
