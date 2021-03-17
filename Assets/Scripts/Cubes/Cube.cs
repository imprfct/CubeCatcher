using UnityEngine;

namespace Assets.Scripts.Cubes
{
    public class Cube: MonoBehaviour
    {
        private Vector3 _targetPoint = new Vector3(0, -5, 0);
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private float _speed;
        
        private void Awake()
        {
            var direction =
                (_targetPoint - transform.position)
                .normalized;

            _rigidbody.velocity = direction * _speed;
        }

        private void FixedUpdate()
        {
            _rigidbody.rotation += 5F;
        }
    }
}
