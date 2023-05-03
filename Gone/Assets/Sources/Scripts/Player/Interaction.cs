using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private GameObject _buttonInteraction;
    [SerializeField] private LayerMask _layeInteraction;

    protected GameObject _currentObject;

    private void Start()
    {
        if (!_buttonInteraction) Debug.LogError($"No link to{_buttonInteraction}");
        if (!_playerMove) Debug.LogError($"No link to{_playerMove}");


        IInputSystem.EventDownE += InteractionObject;
    }

    private void FixedUpdate()
    {
        var tempObject = Physics2D.OverlapCircle(transform.position, _radius, _layeInteraction);

        if (tempObject)
        {
            if (tempObject.TryGetComponent(out IItem item))
            {
                _currentObject = tempObject.gameObject;
                SetPositionButtonInteraction(_currentObject.transform.position, _currentObject.transform.localScale.y);
                SetActiveButtonInteraction(true);
            }
        }
        else
        {
            _currentObject = null;
            SetActiveButtonInteraction(false);
        }
    }

    private void InteractionObject()
    {
        if (_currentObject == null) return;

        Destroy(_currentObject.gameObject);
    }


    private void SetPositionButtonInteraction(Vector2 position, float up = 0)
    {
        _buttonInteraction.transform.position = position + Vector2.up * up;
    }

    private void SetActiveButtonInteraction(bool active)
    {
        _buttonInteraction.SetActive(active);   
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
