using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    Inventory inv;
    GlobalTime timer;
    public int minItems = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inv = GetComponent<Inventory>();
        timer = GetComponent<GlobalTime>();
    }

    // Update is called once per frame
    void Update()
    {
        WinStatus();
    }

    void WinStatus() 
    { 
        if (inv.itemInv.Count >= minItems && timer.currentTime == timer.maxTime) 
        {
            SceneManager.LoadScene("WinScreen");
        }
        else if (inv.itemInv.Count < minItems && timer.currentTime == timer.maxTime) 
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
