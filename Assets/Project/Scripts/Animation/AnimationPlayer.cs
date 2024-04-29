using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameEvent _obj;
    [SerializeField] string _conditionName;
    private void OnEnable()
    {
        _obj.GameAction += RunAnim;
    }
    private void OnDisable()
    {
        _obj.GameAction -= RunAnim;
    }
    void RunAnim()
    {
        if ( _animator != null )
        {
            _animator.SetBool(_conditionName, true);
        }
    }
}
