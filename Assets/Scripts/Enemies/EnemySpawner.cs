using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevGogol.GameCore.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Vector2 _bounds;
        [SerializeField] private float _spawnCoolDown;
        [SerializeField] private int _maxEnemies;
        [SerializeField] private Enemy[] _enemyPrefabs;
        [SerializeField] private Transform _enemyTarget;
        [SerializeField] private ParticleSystem _spawnEffect;

        private List<Enemy> _enemiesAlive = new List<Enemy>();
        private float _coolDownTimer;
    
        private void Start()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                _coolDownTimer -= Time.deltaTime;

                if (_coolDownTimer < 0f && _enemiesAlive.Count < _maxEnemies)
                {
                    var position = transform.position + new Vector3(_bounds.x / 2f * Random.Range(-1f, 1f), 0f,
                        _bounds.y / 2f * Random.Range(-1f, 1f));
                    position.y = 0f;
                    var enemy = SpawnEnemy(position, _enemyTarget);
                    _enemiesAlive.Add(enemy);
                
                    _coolDownTimer = _spawnCoolDown;
                }
            
                yield return null;
            }
        }

        private Enemy SpawnEnemy(Vector3 position, Transform target)
        {
            var randomEnemy = Random.Range(0, _enemyPrefabs.Length);
        
            var enemy = Instantiate(_enemyPrefabs[randomEnemy], position, Quaternion.identity, transform);
            enemy.Init(target);
            enemy.OnDead.AddListenerOnce(() =>
            {
                _enemiesAlive.Remove(enemy);
            });
        
            Instantiate(_spawnEffect, position, Quaternion.identity, transform);
            return enemy;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.2f);
            Gizmos.DrawCube(transform.position, new Vector3(_bounds.x, 1f, _bounds.y));
        }
    }
}