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


    private string[] randomQuest;
    private void Start()
    {
        randomQuest = new string[5] {"Find Lost Item", "Collect/Dispose of 10 Litter", "Find Lost Item", "Collect/Dispose of 20 Litter", "Find Lost Item"};
    }

    public void StartQuest() 
    {
        var element = randomQuest[Random.Range(0, randomQuest.Length)];
        questUI.SetActive(true);
        quest.isActive = true;
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        player.quest = quest;
        Debug.Log(quest.title + " Quest was started");
    }
}
