using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    public void MoveForward()
    {
        transform.position += transform.forward * (_speed * Time.deltaTime);
    }

    public void MoveBack()
    {
        transform.position -= transform.forward * (_speed * Time.deltaTime);
    }
    
    public void RotateLeft()
    {
        transform.rotation *= Quaternion.Euler(0f, -Time.deltaTime * _rotationSpeed, 0f);
    }

    public void RotateRight()
    {
        transform.rotation *= Quaternion.Euler(0f, Time.deltaTime * _rotationSpeed, 0f);
    }
}