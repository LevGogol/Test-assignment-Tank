using UnityEngine;

public class SmoothFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        var hardPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, hardPosition, _speed);
    }
}
