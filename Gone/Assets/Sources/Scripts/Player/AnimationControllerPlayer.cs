using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerPlayer : MonoBehaviour
{
    [SerializeField] private string _nameBoolRun;
    [Space]
    [SerializeField] private Animator _animator;

    private PlayerMove _playerMove;
    
    private void Start()
    {
        if (gameObject.TryGetComponent(out PlayerMove playerMove)) _playerMove = playerMove;
        else Debug.LogError("Failed to get PlayerMove component");
    }

    private void FixedUpdate()
    {
        if(!_playerMove || !_animator) return;

        AnimationMove();
    }

    private void AnimationMove()
    {
        _animator.SetBool(_nameBoolRun, _playerMove.InputHorizontal != 0);

    }
}
