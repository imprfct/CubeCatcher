using UnityEngine;

namespace Assets.Scripts.Cubes
{
    public class Cube : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private Animator _animator;
        
        [SerializeField]
        private float _speed;
        
        private Vector3 _direction;
        private bool isDead = false;
        
        private void Awake()
        {
            SetDirection();
            _rigidbody.velocity = _direction * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == GlobalConstants.BORDER_TAG)
            {
                _animator.SetTrigger("Death");
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.rotation = 0;
                isDead = true;
                
                Destroy(gameObject, .5f);
            }
        }

        private void FixedUpdate()
        {
            if (!isDead)
            {
                _rigidbody.rotation += 5F;
            }
        }

        private void SetDirection()
        {
            var width = Spawner.Instance.Width;
            var height = Spawner.Instance.Height * -1;
            
            var minX = -width / 2;
            var maxX = width / 2;

            var minY = 1;
            var maxY = height;
            
            var targetPoint = new Vector3(x: Random.Range(minX, maxX),
                y: Random.Range(minY, maxY));

            _direction = (targetPoint - transform.position).normalized;
        }
    }
}
