using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Moving : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        
        [SerializeField]
        private float _speed;
        private Vector2 _direction = Vector2.right;

        private void Start()
        {
            _rigidbody.velocity = _direction * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == GlobalConstants.BORDER_TAG)
            {
                ChangePlayerDirection();
            }
        }

        private void ChangePlayerDirection()
        {
            _direction *= -1;
            _rigidbody.velocity = _direction * _speed;
        }
    }
}
