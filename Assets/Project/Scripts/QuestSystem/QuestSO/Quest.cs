using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public List<Objective> objectives = new List<Objective>();
    public List<GameEvent> questObjEvent = new List<GameEvent>();
    public GameEvent questsEvent;

    public int currentObj = 0;
    public bool Done = false;
    private void OnEnable()
    {
        for(int i = 0; i < objectives.Count; i++)
        {
           // questObjEvent[i] = objectives[i].QuestEvent;
            questObjEvent[i].GameAction += UpdateAmmount;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < questObjEvent.Count; i++)
        {
            questObjEvent[i].GameAction -= UpdateAmmount;
        }
    }
    void UpdateAmmount()
    {
        if (currentObj < objectives.Count - 1)
        {
            currentObj++;
        }
        else if (!Done && currentObj <= objectives.Count)
        {
            Done = true;
            questsEvent.GameAction?.Invoke();
        }
    }
}
