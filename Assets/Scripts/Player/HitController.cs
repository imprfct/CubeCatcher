using UnityEngine;

namespace Assets.Scripts.Player
{
    public class HitController : MonoBehaviour
    {
        [SerializeField]
        private GameLogic _game;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == GlobalConstants.ENEMY_TAG)
            {
                _game.GameOver();
            }
        }
    }
}
