using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TriggerCollision : MonoBehaviour
{
    [SerializeField] Flowchart _interact;
    [SerializeField] bool _canInteract = false;
    [SerializeField] string _FCName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canInteract = false;
        }
    }
    private void Update()
    {
        ExcuteFungus();
    }
    void ExcuteFungus()
    {
        if (_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            _interact.ExecuteBlock(_FCName);
        }
    }
}
