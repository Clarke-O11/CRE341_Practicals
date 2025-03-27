using System;
using TMPro;
using UnityEngine;

public class NPC_Talk : MonoBehaviour
{
    public bool playerInRange;

    public bool isTalking;

    TextMeshProUGUI dialogueText;

    public Quest quests;
    private QuestGiver questGiver;
    public Quest currentActiveQuest = null;
    public int activeQuestIndex = 0;
    public bool firstTimeInteraction = true;
    public int currentDialogue;

    Inventory inventory;

    public void StartConversation() 
    { 
        isTalking = true;
        LookAtPlayer();

        if (firstTimeInteraction)   // first time talking to npc
        {
            firstTimeInteraction = false;
            //currentActiveQuest = quests[activeQuestIndex];
            StartQuestDialogue();
            currentDialogue = 0;
            questGiver.StartQuest();
        }
        else 
        {   // quest in progress
            if (currentActiveQuest.isCompleted == false && currentActiveQuest.isActive == true)
            { 
                if (AreQuestRequirementsCompleted()) 
                {
                    //SubmitRequiredItems();
                    questGiver.questUI.SetActive(false);
                    //dialogueText.text = currentActiveQuest.info.questCompleted;
                    isTalking = false;
                }
            }
        }

        if (currentActiveQuest.isCompleted) 
        {
            dialogueText.text = currentActiveQuest.info.questCompleted;
            isTalking = false;
            inventory.hasRequiredItem = false;
        }

        if (currentActiveQuest.initialDialogueCompleted == false)
        {
            StartQuestDialogue();
        }


    }

    private bool AreQuestRequirementsCompleted()
    {
        string requiredItem = currentActiveQuest.info.requiredItem;
        int requiredAmount = currentActiveQuest.info.requirementAmount;

        var itemCounter = 0;

        if (inventory.hasRequiredItem) 
        {
            itemCounter++;
        }

        if (itemCounter >= requiredAmount)
        {
            return true;
        }
        else 
        { 
            return false;
        }

    }

    private void CompleteQuest() 
    { 
        currentActiveQuest.Complete();
        activeQuestIndex++;

        if (activeQuestIndex < 1) 
        {
            //currentActiveQuest = quests[activeQuestIndex];
            currentDialogue = 0;
            currentActiveQuest.isActive = false;
            isTalking = false;
        }
        else
        {
            currentActiveQuest.isActive = false;
            isTalking = false;
        }
    }

    public void LookAtPlayer() 
    { 
        
    }

    private void StartQuestDialogue() 
    { 
        dialogueText.text = currentActiveQuest.info.initialDialogue[currentDialogue];
        currentDialogue++;
        CheckIfDialogueDone();
    }

    private void CheckIfDialogueDone()
    {
        if (currentDialogue == currentActiveQuest.info.initialDialogue.Count - 1)
        {
            dialogueText.text = currentActiveQuest.info.initialDialogue[currentDialogue];
            currentActiveQuest.initialDialogueCompleted = true;
        }
        else 
        { 
            dialogueText.text = currentActiveQuest.info.initialDialogue[currentDialogue];
            CheckIfDialogueDone();
        }
    }
}
