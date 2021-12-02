using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _shootCoolDown;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private float _coolDownTimer;

    private void Update()
    {
        _coolDownTimer -= Time.deltaTime;
    }

    public void TryShoot()
    {
        if (_coolDownTimer > 0f) return;
        _coolDownTimer = _shootCoolDown;
        
        var bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        bullet.Init(_damage);
    }
}