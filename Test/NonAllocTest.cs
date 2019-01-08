using Euclase.ECollections;
using Euclase.EVector3;
using Euclase.Nonalloc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Euclase.Test {
    public class NonAllocTest : EBase {

        [SerializeField] private uint _enemyCount;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private bool _useNonAlloc;

        private List<Enemy> _enemies;
        private List<Enemy> _result;
        private ListTool<Enemy> _;

        void Start() {
            _enemies = new List<Enemy>();
            for(int i = 0; i < _enemyCount; i++) {
                var e = Instantiate(_enemyPrefab,
                    (UnityEngine.Random.insideUnitSphere * 5).Mul(1, 0, 1), Quaternion.identity)
                    .GetComponent<Enemy>();
                e.IsActive = UnityEngine.Random.Range(0, 2) == 0;
                
                _enemies.Add(e);
            }

            _ = new ListTool<Enemy>();
        }

        void Update() {
            if(_useNonAlloc)
                FindClosestEnemyNonAlloc();
            else
                FindClosestEnemy();
        }

        private void FindClosestEnemyNonAlloc() {
            var enemy = _
                .From(_enemies)
                .Where(e => e.IsActive)
                .Where(e => e.CanBeSpotted)
                .ToList()
                //.OrderBy(e => (e.Transform.position - Transform.position).sqrMagnitude)
                .FirstOrDefault();
        }

        private void FindClosestEnemy() {
            var enemy = _enemies
                .Where(e => e.IsActive)
                .Where(e => e.CanBeSpotted)
                //.OrderBy(e => (e.Transform.position - Transform.position).sqrMagnitude)
                .FirstOrDefault();
        }
    }
}
