using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyState_Idle : IEnemyState
{
    public void Enter(AIBase aiBase)
    {
        Debug.Log("Entering Idle State");
        aiBase.agent.isStopped = true;

    }

    public void Update(AIBase aiBase)
    {
        Debug.Log("AI Idle");

        aiBase.agent.speed = 0;
        aiBase.animator.SetBool("Idle", true);
        aiBase.transform.LookAt(aiBase.player);
        aiBase.distanceToPlayer = Vector3.Distance(aiBase.player.transform.position, aiBase.transform.position);

        if (aiBase.distanceToPlayer > 5f)
        {
            aiBase.SetState(new EnemyState_PATROL());
            aiBase.animator.SetBool("Patrol", true);
            //aiBase.textParent.SetActive(false);
            //aiBase.text.enabled = false;
        }

    }

    public void Exit(AIBase aiBase)
    {
        Debug.Log("Exiting Idle State");
    }
}
