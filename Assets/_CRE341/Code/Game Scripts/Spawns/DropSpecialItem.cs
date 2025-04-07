using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropSpecialItem : MonoBehaviour
{
    public int dropChance;

    int randomNumber;
    int randomTimer;

    bool hasDroppedOnce;

    public GameObject specialItemPrefab; //special NPC items
    GameObject itemClone;
    GameObject requiredItem;
    public bool hasRequiredItem;
    bool returnedItem;

    public List<GameObject> playerHasItem = new List<GameObject>();

    public float pickUpRange;
    public Transform player;
    [SerializeField] private LayerMask npcLayer; 
    [SerializeField] private LayerMask interactableLayer;

    private AI_FSM aiState;

    Interactable currentInteractable;
    //public Image itemUI;

    // Update is called once per frame
    void Update()
    {
        randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        //randomTimer = UnityEngine.Random.Range(0, 101);
        if (randomNumber <= dropChance && !hasDroppedOnce)
        {
            ItemDropped();
            returnedItem = false;
        }
        //Vector3 distanceToPlayer = player.position - itemClone.transform.position;
        if (Input.GetKeyDown(KeyCode.E) && hasDroppedOnce && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, 5f, interactableLayer))// (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && hasDroppedOnce && currentInteractable)
        {
            PicksUpItem();
            Debug.Log($"Picked up {specialItemPrefab}.");
        }

        AreRequirementsCompleted();
    }

    public void ItemDropped()
    {
        itemClone = (GameObject)Instantiate(specialItemPrefab, this.transform.position, Quaternion.identity); 
        hasDroppedOnce = true;
        requiredItem = itemClone;
    }

    private void AreRequirementsCompleted()
    {
        if (playerHasItem.Contains(requiredItem))
        { 
            hasRequiredItem = true;

            if (hasRequiredItem && Input.GetKeyDown(KeyCode.R) && !returnedItem && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, 3f, npcLayer)) //interacting with or looking at npc
            {
                // give item to npc
                returnedItem = true;
                hasDroppedOnce = false;
                playerHasItem.Remove(specialItemPrefab);
                //itemUI.enabled = false;
                aiState.playerVisible = true;
            }
        }
    }

    private void PicksUpItem() 
    {
        playerHasItem.Add(requiredItem);
        //itemUI.enabled = true;
    }
}
