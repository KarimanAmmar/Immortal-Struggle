using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] QuestsListManager _quests;
    [SerializeField] TextMeshProUGUI _questTxt;
    [SerializeField] TextMeshProUGUI _objTxt;
    [SerializeField] int _currentQuest;

    string _obj;
    private void Update()
    {
        //Update UI Quests
        SetQuestsInUI();
    }
    void SetQuestsInUI()
    {
        if (_currentQuest < _quests.Quests.Count - 1)
        {
            _currentQuest = _quests.currentQuest;
        }
        _questTxt.text = _quests.Quests[_currentQuest].questName;
        _obj = null;

        for (int i = 0; i < _quests.Quests[_currentQuest].objectives.Count; i++)
        {
            _obj = _obj + "\n" + _quests.Quests[_currentQuest].objectives[i].objectiveName;
        }
        _objTxt.text = _obj;
    }
}