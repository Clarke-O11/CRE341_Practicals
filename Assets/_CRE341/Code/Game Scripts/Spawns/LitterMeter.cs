using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LitterMeter : MonoBehaviour
{
    private SpawnItems spawner;
    private int litterCount;
    public int maxCount = 70;
    private AIBase dropItem;
    private Inventory inv;

    public Slider meter;
    public Image fillMeter;
    public Gradient gradient;

    public GameObject NPC_00;

    private void Start()
    {
       //dropItem = GetComponent<AIBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dropItem != null)
        {
            litterCount = this.spawner.numberOfItems += NPC_00.GetComponent<AIBase>().droppedCount;//dropItem.droppedCount;
            UpdateLitterMeter();
            Debug.Log("no null reference");
        }
        else 
        { 
            Debug.Log("dropItem is null"); 
        }
    }
    void UpdateLitterMeter() 
    {
        if (inv.itemAmount >= 1)
        {
            litterCount -= 1;
            Debug.Log("Littercount = " + litterCount);
        }

        meter.value = litterCount / maxCount * 100;
        fillMeter.color = gradient.Evaluate(meter.normalizedValue);
    }
}
