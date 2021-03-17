using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameLogic: MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOverPanel;
        
        public void GameOver()
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }

        public void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            _gameOverPanel.SetActive(false);
        }
    }
}
