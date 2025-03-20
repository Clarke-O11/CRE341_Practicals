using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public GameObject requiredItem;
    public GameObject currentItem;
    public bool IsReached() 
    {
        return (currentAmount >= requiredAmount);
    }

    public void Goal() 
    {
        if (goalType == GoalType.Find)
        {
            // what does the player need to find - listener
        }

        if (goalType == GoalType.Collect)
        {
            currentAmount++;
        }
    }
}

public enum GoalType 
{ 
    Find,
    Collect
}
