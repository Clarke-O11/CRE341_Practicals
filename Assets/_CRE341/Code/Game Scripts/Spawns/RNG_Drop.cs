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

    private void Start()
    {
        //randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        //randomTimer = UnityEngine.Random.Range(0, 11); //10-20, 10-100
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        randomTimer = UnityEngine.Random.Range(19, 60); //10-60
        if (randomNumber <= dropChance && spawning == false) 
        { 
            StartCoroutine(ItemDropped());
        }       
    }

    public IEnumerator ItemDropped() 
    { 
        //if (randomNumber <= dropChance) 
        Instantiate(itemDropped, this.transform.position, Quaternion.identity);
        spawning = true;
        yield return new WaitForSeconds(randomTimer);
        spawning = false;
    }
}
