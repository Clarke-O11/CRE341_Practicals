using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class EnemyState_Idle : IEnemyState
{
    public void Enter(AIBase aiBase)
    {
        Debug.Log("Entering Idle State");
        

    }

    public void Update(AIBase aiBase)
    {
        Debug.Log("AI Idle");

        aiBase.agent.speed = 0;
        aiBase.animator.SetBool("Idle", true);

        /*if (aiBase.distanceToPlayer > 5f)
        {
            aiBase.SetState(new EnemyState_PATROL());
        }*/

    }

    public void Exit(AIBase aiBase)
    {
        Debug.Log("Exiting Idle State");
        aiBase.SetState(new EnemyState_PATROL());
    }
}
