using UnityEngine;

public class NPC_Behaviour : MonoBehaviour
{
    Animator fsm_anim; // top level animator for the AI FSM
    [SerializeField] private Animator AIState_Patrol; // child animator for the AI FSM
    [SerializeField] private Animator AIState_Talk; // child animator for the AI FSM

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fsm_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fsm_anim.GetCurrentAnimatorStateInfo(0).IsName("Patrol"))
        {
            Debug.Log("Patrol State");
            AIState_Patrol.enabled = true;
            AIState_Talk.enabled = false;
        }
        else if (fsm_anim.GetCurrentAnimatorStateInfo(0).IsName("Talk"))
        {
            Debug.Log("Talk State");
            AIState_Patrol.enabled = false;
            AIState_Talk.enabled = true;
        }

    }

}
