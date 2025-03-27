using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;

    public QuestGoal goal;

    public bool isCompleted;
    public bool initialDialogueCompleted;

    public QuestInfo info;

    public void Complete() 
    { 
        isActive = false;
        isCompleted = true;
        Debug.Log(title + " was complete");
    }
}
