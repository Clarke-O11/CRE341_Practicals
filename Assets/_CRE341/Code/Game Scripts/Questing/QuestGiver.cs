using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerQuest player;

    public GameObject questUI;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;


    public string[] randomQuest;
    private void Start()
    {
        //randomQuest = new string[3] {"Find the Lost Item", "Collect/Dispose of 10 Litter", "Collect/Dispose of 20 Litter"};
    }

    public void StartQuest() 
    {
        //var element = randomQuest[Random.Range(0, randomQuest.Length)];
        questUI.SetActive(true);
        quest.isActive = true;
        //titleText.text = randomQuest.ToString();
        //descriptionText.text = quest.description;
        player.quest = quest;
        Debug.Log(quest.title + " Quest was started");
    }
}
