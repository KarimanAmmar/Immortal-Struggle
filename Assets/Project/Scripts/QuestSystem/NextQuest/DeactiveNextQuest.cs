using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveNextQuest : MonoBehaviour
{
    [SerializeField] List<GameEvent> _quests;

    bool _done = false;

    private void Update()
    {
        DeactiveQuest();
    }
    // Invoke the Quest Event to be done And remove it from the next quest
    void DeactiveQuest()
    {
        if (!_done && _quests != null)
        {
            for (int i = 0; i < _quests.Count; i++)
            {
                _quests[i].GameAction?.Invoke();
            }
            _done = true;
        }
    }
}
