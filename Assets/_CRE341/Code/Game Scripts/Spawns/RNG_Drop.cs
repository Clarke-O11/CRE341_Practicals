using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RNG_Drop : MonoBehaviour
{
    public GameObject itemDropped;
    public int dropChance;

    int randomNumber;
    int randomTimer;

    bool spawning = false;
    public int droppedCount;
    public int maxDropped = 50;

    // Update is called once per frame
    void Update()
    {
        randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        randomTimer = UnityEngine.Random.Range(19, 60); //10-60
        if (randomNumber <= dropChance && spawning == false && droppedCount < maxDropped) 
        { 
            StartCoroutine(ItemDropped());
        }    
    }

    public IEnumerator ItemDropped() 
    { 
        //if (randomNumber <= dropChance) 
        Instantiate(itemDropped, this.transform.position, Quaternion.identity);
        spawning = true;
        droppedCount += 1;
        yield return new WaitForSeconds(randomTimer);
        spawning = false;
    }
}
