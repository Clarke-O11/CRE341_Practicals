using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    Inventory inv;
    GlobalTime timer;
    //public int minItems = 10;
    LitterMeter litter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GetComponent<Inventory>();
        timer = GetComponent<GlobalTime>();
        litter = GetComponent<LitterMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        WinStatus();
    }

    void WinStatus() 
    { 
        if (timer.timeFinished) 
        {
            if (litter.meter.value < 70) // || inv.itemInv.Count >= minItems 
            { 
                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }

        /*if (inv.itemInv.Count >= minItems && timer.timeFinished == true) 
        {
            SceneManager.LoadScene("WinScreen");
        }
        else if (inv.itemInv.Count < minItems && timer.timeFinished == true) 
        {
            SceneManager.LoadScene("LoseScreen");
        }*/
    }
}