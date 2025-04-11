using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Image tutorial;
    public TextMeshProUGUI intro;
    public TextMeshProUGUI tutorialText;

    bool canShow;
    bool isActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorial.enabled = true;
        intro.enabled = true;
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
            tutorialText.enabled = true;
            intro.enabled = false;
            isActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            tutorialText.enabled = false;
            intro.enabled = false;
            isActive = false;
            canShow = false;
            tutorial.enabled = false;
        }
    }
}
