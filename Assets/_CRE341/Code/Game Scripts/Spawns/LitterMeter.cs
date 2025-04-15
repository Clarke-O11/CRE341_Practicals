using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LitterMeter : MonoBehaviour
{
    private SpawnItems spawner;
    public float litterCount;
    public float maxCount = 70f;
    private AIBase dropItem;
    private Inventory inv;

    public Slider meter;
    public Image fillMeter;
    public Gradient gradient;

    public GameObject NPC_00;
    public TextMeshProUGUI litterPercentage;

    private void Start()
    {
       //dropItem = GetComponent<AIBase>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLitterMeter();
        dropItem = NPC_00.GetComponent<AIBase>();
        spawner = this.GetComponent<SpawnItems>();
        if (dropItem != null)
        {
            litterCount = spawner.numberOfItems += dropItem.droppedCount;//NPC_00.GetComponent<AIBase>().droppedCount;
            UpdateLitterMeter();
            litterPercentage.text = meter.value.ToString() + "%";
            Debug.Log("no null reference");
        }
        else 
        { 
            Debug.Log("dropItem is null"); 
        }
    }
    void UpdateLitterMeter() 
    {
        GameObject player = GameObject.FindWithTag("Player");
        inv = player.GetComponent<Inventory>();
        if (inv.itemAmount >= 1)
        {
            litterCount -= 1f;
            Debug.Log("Littercount = " + litterCount);
        }

        meter.value = (litterCount / maxCount) * 100f;
        if (meter.value >= maxCount) 
        {
            litterPercentage.color = Color.red;
        }
        else 
        {
            litterPercentage.color = Color.white;
        }
        //litterPercentage.text = meter.value.ToString() + "%";
        fillMeter.color = gradient.Evaluate(meter.normalizedValue);
    }
}
