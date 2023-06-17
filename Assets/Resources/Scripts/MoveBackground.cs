using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]private float _offset;
    [SerializeField]private float _power;
    private Transform _transform;
    private float _backSize;
    private float _backPosition;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _backSize = GetComponent<SpriteRenderer>().bounds.size.y;
        Debug.Log(_backSize);
    }

    public void Move(Vector2 value)
    {
        Debug.Log(value.y);
        _backPosition += (value.y + _offset) * _power;
        _backPosition = Mathf.Repeat(_backPosition, _backSize);
        if (_backPosition < -7)
        {
            _backPosition = -7;
        }
        _transform.position = new Vector3(_transform.position.x, _backPosition, _transform.position.z);
    }
}
