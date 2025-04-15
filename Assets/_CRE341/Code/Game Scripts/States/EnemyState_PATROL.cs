using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.Events;

public class EnemyState_PATROL :  IEnemyState
{

    public void Enter(AIBase aiBase)
    {
        Debug.Log("Entering Patrol State");
        aiBase.agent.speed = 4;
        //aiBase.agent.Resume();
        aiBase.agent.isStopped = false;
    }
    public void Update(AIBase aiBase)
    {
      
        Debug.Log("AIPatroling");
        aiBase.PatrolPoints();

        aiBase.distanceToPlayer = Vector3.Distance(aiBase.player.transform.position, aiBase.transform.position);
        if (aiBase.distanceToPlayer <= 5f)
        {
            aiBase.SetState(new EnemyState_Idle());
        }
        
        aiBase.Dropping();
        

        aiBase.itemRandomNumber = UnityEngine.Random.Range(0, 201); //1-200
        //itemRandomTimer = UnityEngine.Random.Range(0, 101);
        if (aiBase.itemRandomNumber <= aiBase.itemDropChance && !aiBase.hasDroppedOnce)
        {
            aiBase.SpecialItemDropped();
            aiBase.returnedItem = false;
        }
        //Vector3 distanceToPlayer = player.position - itemClone.transform.position;
        if (Input.GetKeyDown(KeyCode.E) && aiBase.hasDroppedOnce && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, 5f, aiBase.interactableLayer))// (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && hasDroppedOnce && currentInteractable)
        {
            aiBase.PicksUpItem();
            Debug.Log($"Picked up {aiBase.specialItemPrefab}.");
        }

        aiBase.AreRequirementsCompleted();

      }
      public void Exit(AIBase aiBase)
      {

          Debug.Log("Exiting patrol State");
      }
}
