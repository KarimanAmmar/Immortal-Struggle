using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideTheBoat : MonoBehaviour
{
    [SerializeField] GameEvent _ride;
    [SerializeField] GameObject _boat;

    private void OnEnable()
    {
        _ride.GameAction += ConvertToChild;
    }
    private void OnDisable()
    {
        _ride.GameAction -= ConvertToChild;
    }
    void ConvertToChild()
    {
        transform.parent = _boat.transform;
    }
}
