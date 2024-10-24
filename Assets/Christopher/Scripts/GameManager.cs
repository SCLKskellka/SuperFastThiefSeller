using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Christopher.Scripts
{
    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public GameObject Player;
        
        [SerializeField] private Transform playerStartPos; 
        [Header("UI Elements")]
        [SerializeField] private GameObject inGameUI;
        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private GameObject pauseMenuUI;
        public GameObject tradingMenuUI;
        [Header("trading step")]
        [SerializeField] private Inventory inventory;

        private void Awake() {
            Time.timeScale = 0;
            mainMenuUI.SetActive(true);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(false);
        }

        public void InitializeGameSequence() {
            Player.transform.position = playerStartPos.position;
            Player.transform.GetComponent<Player>().ResetPlayer();
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
            tradingMenuUI.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void ResetGameSequence() {
            Player.transform.position = playerStartPos.position;
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(true);
            tradingMenuUI.SetActive(false);
            Time.timeScale = 1;
        }

        public void TradingSequence() {
            mainMenuUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            inGameUI.SetActive(false);
            tradingMenuUI.SetActive(true);
            Time.timeScale = 0;
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
            Time.timeScale = 1;
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
