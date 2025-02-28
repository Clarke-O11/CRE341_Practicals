using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;
    [SerializeField] private GameObject crosshairFill;
    public void EnableInteractionText(string text) 
    { 
        interactionText.text = text;
        crosshairFill.SetActive(true);
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        crosshairFill.SetActive(false);
        interactionText.gameObject.SetActive(false);
    }
}
