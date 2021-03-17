using System.Collections.Generic;
using UnityEngine;

// using Random = System.Random;

namespace Assets.Scripts.Cubes
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _cubes;

        [Header("Parameters")]
        [SerializeField]
        private float _newEnemyCooldown;
        [SerializeField]
        private float _width = 15;
        [SerializeField]
        private float _height = 6;

        private float _timer;

        private void Start()
        {
            _timer = _newEnemyCooldown;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = _newEnemyCooldown;

                var enemy = _cubes[Random.Range(0, _cubes.Count)];

                var rotation = Random.rotation;
                rotation.x = 0;
                rotation.y = 0;

                Instantiate(enemy, GetSpawnPoint(), rotation);
            }
        }

        private Vector2 GetSpawnPoint()
        {
            var minX = -_width / 2;
            var maxX = _width / 2;

            var y = _height;

            return new Vector2(Random.Range(minX, maxX), y);
        }
    }
}
