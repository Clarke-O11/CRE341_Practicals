using UnityEngine;
using UnityEngine.UI;

public class LitterMeter : MonoBehaviour
{
    private SpawnItems spawner;
    private int litterCount;
    private int maxCount = 70;
    public RNG_Drop dropItem;
    private Inventory inv;

    public Slider meter;
    public Image fillMeter;
    public Gradient gradient;

    private void Start()
    {
       dropItem = GameObject.Find("NPC_00").GetComponent<RNG_Drop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dropItem != null)
        {
            litterCount = this.spawner.numberOfItems += dropItem.droppedCount;
            Debug.Log($"There are {litterCount} amount(s) of Litter");
        }
        else 
        { 
            Debug.Log("No dropItem found"); 
        }
        UpdateLitterMeter();
    }
    void UpdateLitterMeter() 
    {
        CheckForPickUp();
        meter.value = litterCount / maxCount * 100;
        fillMeter.color = gradient.Evaluate(meter.normalizedValue);
    }

    void CheckForPickUp() 
    {
        if (inv.itemAmount >= 1) 
        { 
            litterCount -= 1;
        }
    }
}
