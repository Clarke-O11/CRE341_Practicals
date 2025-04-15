using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    Inventory inv;
    GlobalTime timer;
    //public int minItems = 10;
    LitterMeter litter;
    public GameObject meter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GetComponent<Inventory>();
        timer = GetComponent<GlobalTime>();
        litter = meter.GetComponent<LitterMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        WinStatus();

        if (litter == null) 
        {
            litter = meter.GetComponent<LitterMeter>();
            Debug.Log("Can't find LitterMeter");
        }
    }

    void WinStatus() 
    {
        if (timer.timeFinished) 
        {
            if (litter.litterCount < litter.maxCount) // || inv.itemInv.Count >= minItems 
            { 
                SceneManager.LoadScene("WinScreen");
                Debug.Log("Player Win");
            }
            else
            {
                SceneManager.LoadScene("LoseScreen");
                Debug.Log("Player Lose");
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