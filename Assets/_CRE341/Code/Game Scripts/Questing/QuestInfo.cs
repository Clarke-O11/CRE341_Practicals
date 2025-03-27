using NUnit.Framework;
using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/QuestInfo", order = 1)]
public class QuestInfo : ScriptableObject
{
    [TextArea(5,10)]
    public List<string> initialDialogue;
    [TextArea(5, 10)]
    public string questCompleted;

    public string requiredItem;
    public int requirementAmount;
}
