using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public Quest quest;
    public QuestGiver questGiver;

    public void CurrentQuest() 
    {
        if (quest.isActive)
        {
            quest.goal.Goal();
            if (quest.goal.IsReached()) 
            { 
                questGiver.questUI.SetActive(false);
                quest.Complete();
            }
        }
    }
}
