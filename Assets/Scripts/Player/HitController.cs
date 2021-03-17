using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class HitController : MonoBehaviour
    {
        public Action OnCoinCollected;
        public Action OnDeath;
        
        [SerializeField]
        private GameLogic _game;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == GlobalConstants.ENEMY_TAG)
            {
                OnDeath?.Invoke();
            }
            else if (collision.collider.tag == GlobalConstants.COIN_TAG)
            {
                Destroy(collision.collider.gameObject);
                OnCoinCollected?.Invoke();
            }
        }
    }
}
