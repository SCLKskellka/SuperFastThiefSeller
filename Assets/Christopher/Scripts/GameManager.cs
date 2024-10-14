using System;
using UnityEngine;

namespace Christopher.Scripts
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        [SerializeField] private Transform playerStartPos;
        [SerializeField] private GameObject player;
        [Header("UI Elements")]
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GameObject tradingMenuUI;
        private bool _tradingSequence;

        private void Awake() {
            Time.timeScale = 0;
            mainMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(false);
        }

        public void InitializeGameSequence() {
            player.transform.position = playerStartPos.position;
            player.transform.GetComponent<Player>().ResetPlayer();
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
            tradingMenuUI.SetActive(false);
            Time.timeScale = 1;
            _tradingSequence = false;
        }
        
        public void ResetGameSequence() {
            player.transform.position = playerStartPos.position;
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
            tradingMenuUI.SetActive(false);
            Time.timeScale = 1;
            _tradingSequence = false;
        }

        public void TradingSequence()
        {
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(true);
            _tradingSequence = true;
        }

        public void Pause() {
            Time.timeScale = 0;
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(false);
        }
        public void Resume() {
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            
            if (_tradingSequence) {
                tradingMenuUI.SetActive(true);
                inGameUI.SetActive(false);
            }
            else {
                tradingMenuUI.SetActive(false);
                inGameUI.SetActive(true);
                Time.timeScale = 1;
            }
        }

        public void LeaveGameSequence() {
            Time.timeScale = 0;
            mainMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(false);
        }

        public void LeaveApp() { Application.Quit(); }
   
    }
}
