using LevGogol.GameCore.Tanks;
using UnityEngine;
using UnityEngine.Events;

namespace LevGogol.GameCore.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public UnityEvent OnDead = new UnityEvent();
    
        [SerializeField] private float _health;
        [SerializeField] private float _damage;
        [SerializeField] private float _defence;
        [SerializeField] private float _speed;
        [SerializeField] private EnemyAI _ai;

        private Transform _target;

        public void Init(Transform target)
        {
            _target = target;
        }
    
        private void Update()
        {
            Move(_ai.Direction(_target));
        }

        public void Move(Vector3 direction)
        {
            direction = direction.normalized;
            transform.position += direction * Time.deltaTime * _speed;
        }
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent<Tank>(out var tank))
            {
                tank.DamageWithDefence(_damage);
                Dead();
            }
        }

        public void TakeDamageWithDefence(float damage)
        {
            _health = _health - (damage * _defence);
        
            if(_health < 0f) Dead();
        }

        public void Dead()
        {
            OnDead.Invoke();
        
            Destroy(gameObject);
        }
    }
}

