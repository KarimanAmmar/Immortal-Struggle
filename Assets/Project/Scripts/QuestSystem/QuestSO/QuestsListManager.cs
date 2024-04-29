using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/QuestsList")]
public class QuestsListManager : ScriptableObject
{
    public List<Quest> Quests = new List<Quest>();
    [SerializeField] public GameEvent QuestCompleted;
    public int currentQuest = 0;
    
    private void OnEnable()
    {
        QuestCompleted.GameAction += UpdateAmmount;
    }
    private void OnDisable()
    {
        QuestCompleted.GameAction -= UpdateAmmount;
    }
    void UpdateAmmount()
    {
        if(currentQuest < Quests.Count)
        {
            currentQuest++;
        }
    }
}
