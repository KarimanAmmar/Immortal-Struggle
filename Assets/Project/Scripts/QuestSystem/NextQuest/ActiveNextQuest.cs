using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNextQuest : MonoBehaviour
{
    [SerializeField] GameEvent _lastQuestEvent;
    [SerializeField] List<BoxCollider> _objColiders = new List<BoxCollider>();

    private void OnEnable()
    {
        if (_lastQuestEvent != null)
        {
            _lastQuestEvent.GameAction += ActiveQuest;
        }
    }
    private void OnDisable()
    {
        if (_lastQuestEvent != null)
        {
            _lastQuestEvent.GameAction -= ActiveQuest;
        }
    }
    // Enable colliders so the player be able to invoke the next quest event
    void ActiveQuest()
    {
        if(_objColiders != null)
        {
            for (int i = 0; i < _objColiders.Count; i++)
            {
                _objColiders[i].enabled = true;
            }
        }
    }
}

