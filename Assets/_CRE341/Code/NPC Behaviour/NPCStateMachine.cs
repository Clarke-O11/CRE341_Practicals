using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateMachine: MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject NPC;
    public Transform player;
    public Animator animator;
    public Vector3 playerPosition;

    // States
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float sightRange;
    public bool playerInSightRange;
    public bool chasingPlayer;

    public LayerMask GroundLayers, whatIsPlayer;

    void Start() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>(); 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        Vector3 playerPosition = Vector3.zero;

        if (!playerInSightRange)
        {
            Patroling();
        }

        if (playerInSightRange)
        {
            ChasePlayer();
        }
    }

    public void Patroling() 
    {
        if (!walkPointSet) SearchWalkPoint();
        chasingPlayer = false;

        if (walkPointSet)
        { 
            agent.SetDestination(walkPoint);
            Debug.Log("Walking, Player not in sight");
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
        
    }

    private void SearchWalkPoint() 
    { 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundLayers)) 
        { 
            walkPointSet = true;
        }
    }

    private void ChasePlayer() 
    { 
        agent.SetDestination(playerPosition);
        agent.speed = 5f;
        chasingPlayer= true;
        Debug.Log("Chasing Player");
    }
}
