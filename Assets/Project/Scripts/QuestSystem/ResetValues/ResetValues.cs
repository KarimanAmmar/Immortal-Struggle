using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetValues : MonoBehaviour
{
    [SerializeField] QuestsListManager _quests;
    void Start()
    {
        ResetSOValues();
    }
    //reset all the scribtableObjects values 
    private void ResetSOValues()
    {
        _quests.currentQuest = 0;
        for(int i = 0; i < _quests.Quests.Count; i++)
        {
            _quests.Quests[i].Done = false;
            _quests.Quests[i].currentObj = 0;
           // quests.Quests[i].questObjEvent[i] = quests.Quests[i].objectives[i].QuestEvent;

            for (int j = 0; j < _quests.Quests[i].objectives.Count; j++)
            {
                _quests.Quests[i].objectives[j].currentAmount = 0;
                _quests.Quests[i].objectives[j].Done = false;
            }
        }

    }
}
