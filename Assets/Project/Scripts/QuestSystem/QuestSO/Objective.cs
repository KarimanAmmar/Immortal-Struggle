using UnityEngine;
using UnityEngine.Events;

public enum ObjectiveType
{
    Collectable,
    Fill,
    Damage,
    Door,
    Boat
}

[CreateAssetMenu(fileName = "New Objective", menuName = "Quest System/Objective")]
public class Objective : ScriptableObject
{
    [SerializeField] ObjectiveType _type;
    [SerializeField] public string objectiveName;
    [SerializeField] int _targetAmount;
    [SerializeField] GameEvent _ItemEvent;
    [SerializeField] public GameEvent QuestEvent;

    [HideInInspector]
    public bool Done = false;
    [HideInInspector]
    public int currentAmount ;

    private void OnEnable()
    {
        _ItemEvent.GameAction += UpdateAmmount;
    }
    private void OnDisable()
    {
        _ItemEvent.GameAction -= UpdateAmmount;
    }
    public bool IsCompleted()
    {
        return currentAmount >= _targetAmount;
    }
    void UpdateAmmount()
    {
        if (currentAmount < _targetAmount - 1)
        {
            currentAmount++;
        }
        else if (!Done && currentAmount <= _targetAmount)
        {
            QuestEvent.GameAction?.Invoke();
            Done = true;
        }
    }
}