using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteEvent : MonoBehaviour
{
    [SerializeField] private Flowchart _interact;
    [SerializeField] private GameEvent _collectEvent;
    [SerializeField] private GameObject _text;
    [SerializeField] private bool _completed = false;

    private bool _inRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_text != null)
            {
                _text.SetActive(true);
            }
            _inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_text != null)
            {
                _text.SetActive(false);
            }
            _inRange = false;
        }
    }

    private void Update()
    {
        collect();
    }
    void collect()
    {
        if (_inRange && !_completed && Input.GetKeyDown(KeyCode.E))
        {
            if(_interact != null)
            {
               _interact.ExecuteBlock("Collect");
            }
            if(_collectEvent != null)
            {
                _collectEvent.GameAction?.Invoke();
            }
            _completed = true;
        }
    }
}
