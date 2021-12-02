using LevGogol.GameCore.Enemies;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * _speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamageWithDefence(_damage);
            Destroy(gameObject);
        }
    }
}