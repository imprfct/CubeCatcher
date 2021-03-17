using System;
using Assets.Scripts.Player;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameLogic: MonoBehaviour
    {
        [SerializeField]
        private HitController _hitController;
        [SerializeField]
        private GameObject _gameOverPanel;
        [SerializeField]
        private Text _scoreLabel;
        [SerializeField]
        private Text _scoreGameOverLabel;

        private float _collectedCoins;
        private bool isPaused = false;
        
        private void Awake()
        {
            _hitController.OnCoinCollected += OnCoinCollected;
            _hitController.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            GameOver();
        }

        private void OnCoinCollected()
        {
            _collectedCoins++;
            _scoreLabel.text = _collectedCoins.ToString();
        }

        private void GameOver()
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            _scoreGameOverLabel.text = _collectedCoins.ToString();
        }
        
        [UsedImplicitly]
        public void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            _gameOverPanel.SetActive(false);
        }

        public void Pause()
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }
}
