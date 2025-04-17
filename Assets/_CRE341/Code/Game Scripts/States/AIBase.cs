using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.Cinemachine;
using TMPro;

public class AIBase : MonoBehaviour
{
    public NavMeshAgent agent;

    private IEnemyState currentState;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    public Transform centrePoint;
    public int range = 50;
    public Vector3 point;
    public float distanceToPlayer;

    [Header("Detection Settings")]
    public float detectionRadius = 5f;   
    public bool playerDetected;

    [Header("RNG Drop")]
    public GameObject itemDropped;
    public int dropChance;
    public int randomNumber;
    public int randomTimer;
    public bool spawning = false;
    public int droppedCount;
    public float maxDropped = 50;
    public GameObject[] litter;

    [Header("Drop Special Item")]
    public int itemDropChance;
    public int itemRandomNumber;
    public int itemRandomTimer;
    public bool hasDroppedOnce;
    public GameObject specialItemPrefab; //special NPC items
    GameObject itemClone;
    GameObject requiredItem;
    public bool hasRequiredItem;
    public bool returnedItem;
    public List<GameObject> playerHasItem = new List<GameObject>();
    public float pickUpRange;
    [SerializeField] private LayerMask npcLayer;
    public LayerMask interactableLayer;
    private AI_FSM aiState;
    Interactable currentInteractable;
    public GameObject itemUI;

    [Header("Animator")]
    public Animator animator;

    //[Header("Dialogue")]
    //public List<string> lines = new List<string>();
    //public TextMeshProUGUI text;
    //public GameObject textParent;
    private void Awake()
    {
  
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //lines = new List<string>();
        
    }

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        SetState(new EnemyState_PATROL());

        //textParent.SetActive(false);
        //text.enabled = false;

    }


    private void Update()
    {
        currentState?.Update(this);

    

        if (player != null)
        {
            DetectPlayerInRadius();
        }
    }

    public void DetectPlayerInRadius()
    {
        playerDetected = Physics.CheckSphere(transform.position, detectionRadius, whatIsPlayer);
        

        Debug.Log("Player detected within radius!");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void SetState(IEnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public string GetCurrentStateName()
    {
        return currentState != null ? currentState.GetType().Name.Replace("AI", "") : "No State";
    }

    private void LocatePlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }




    public void PatrolPoints()
    {
         if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.red, 1.0f);
                agent.SetDestination(point);
            }
        }
    }
    
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        if (NavMesh.SamplePosition(center + Random.insideUnitSphere * range, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
    
        result = Vector3.zero;
        return false;
    }

    public void Dropping()
    {
        randomNumber = UnityEngine.Random.Range(0, 101); //1-100
        randomTimer = UnityEngine.Random.Range(9, 20); //10-20
        if (randomNumber <= dropChance && spawning == false && droppedCount < maxDropped)
        {
            StartCoroutine(ItemDropped());
        }
    }
    public IEnumerator ItemDropped()
    {
        //if (randomNumber <= dropChance) 
        //litter[Random.Range(0, lines.Count)];
        Instantiate(litter[Random.Range(0, litter.Length)], this.transform.position, Quaternion.identity);
        //Instantiate(itemDropped, this.transform.position, Quaternion.identity);
        spawning = true;
        droppedCount += 1;
        yield return new WaitForSeconds(randomTimer);
        spawning = false;
    }

    //public void Dialogue() 
    //{
    //    text.enabled = true;
    //    //textParent.SetActive(true);
    //    string dialogue = lines[Random.Range(0, lines.Count)];
    //    text = textParent.GetComponent<TextMeshProUGUI>();
    //    text.text = dialogue;
    //}

    /*public void SpecialItemDropped()
    {
        itemClone = (GameObject)Instantiate(specialItemPrefab, this.transform.position, Quaternion.identity);
        hasDroppedOnce = true;
        requiredItem = itemClone;
    }
    public void AreRequirementsCompleted()
    {
        if (playerHasItem.Contains(requiredItem))
        {
            hasRequiredItem = true;

            if (hasRequiredItem && Input.GetKeyDown(KeyCode.R) && !returnedItem && distanceToPlayer <= 5f)//Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, 3f, npcLayer)) //interacting with or looking at npc
            {
                // give item to npc
                returnedItem = true;
                hasDroppedOnce = false;
                playerHasItem.Remove(specialItemPrefab);
                itemUI.SetActive(false);
                aiState.playerVisible = true;
            }
        }
    }

    public void PicksUpItem()
    {
        playerHasItem.Add(requiredItem);
        itemUI.SetActive(true);
    }*/
}
