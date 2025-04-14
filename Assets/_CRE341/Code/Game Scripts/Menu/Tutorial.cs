using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Tutorial : MonoBehaviour
{
    public Image tutorial;
    public GameObject intro;
    public GameObject tutorialText;
    private GlobalTime timer;

    bool canShow;
    bool isActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //tutorial.enabled = true;
        intro.SetActive(true);
        canShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Text();   
    }

    void Text() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isActive && canShow) 
        {
            tutorialText.SetActive(true);
            intro.SetActive(false);
            isActive = true;
            if (Input.GetKeyDown(KeyCode.Space) && isActive)
            {
                tutorialText.SetActive(false);
                //intro.gameObject.SetActive(false);
                isActive = false;
                canShow = false;
                tutorial.gameObject.SetActive(false);
            }
        }
    }
}
