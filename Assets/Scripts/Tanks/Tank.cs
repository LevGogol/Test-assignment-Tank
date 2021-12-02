using UnityEngine;
using UnityEngine.Events;

namespace LevGogol.GameCore.Tanks
{
    public class Tank : MonoBehaviour
    {
        public UnityEvent OnDead;
        public Movement Movement => _movement;
    
        [SerializeField] private float _health;
        [SerializeField] private float _defence;

        [SerializeField] private Movement _movement;
        [SerializeField] private Weapon[] _weapons;
        [SerializeField] private Weapon _currentWeapon;

        private int _currentWeaponIndex;

        public void TryShoot()
        {
            _currentWeapon.TryShoot();
        }
    
        public void NextWeapon()
        {
            Destroy(_currentWeapon.gameObject);
        
            _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Length;
            _currentWeapon = Instantiate(_weapons[_currentWeaponIndex], _currentWeapon.transform.position, _currentWeapon.transform.rotation, _currentWeapon.transform.parent);
        }

        public void PreviousWeapon()
        {
            Destroy(_currentWeapon.gameObject);
        
            _currentWeaponIndex = (_currentWeaponIndex - 1) % _weapons.Length;
            _currentWeaponIndex = _currentWeaponIndex < 0 ? _weapons.Length - 1 : _currentWeaponIndex;
            _currentWeapon = Instantiate(_weapons[_currentWeaponIndex], _currentWeapon.transform.position, _currentWeapon.transform.rotation, _currentWeapon.transform.parent);
        }

        public void DamageWithDefence(float damage)
        {
            _health = _health - (damage * _defence);

            if (_health < 0f)
            {
                Dead();
            }
        }

        private void Dead()
        {
            gameObject.SetActive(false);
            OnDead.Invoke();
        }
    }
}

