using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotTheDifference
{
    public class GameManager : MonoBehaviour
    {
        //Managers
        public LevelManager levelManager;
        public SoundManager soundManager;
        public UIController uiController;
        
        private static GameManager _instance;
        public static GameManager Instance => _instance;
        
        private void Awake()
        {
            Application.targetFrameRate = 60;
            _instance = this;
            //Initialize is a kind of awake function
            //I want to wake my managers up the order I specify 
            levelManager.Initialize();
            uiController.Initialize();
            soundManager.Initialize();
        }

        public void LevelCompleted()
        {
            //I want my GameManager give orders to my managers the order I specify
            levelManager.LevelCompleted();
            uiController.LevelCompleted();
        }

        public void LevelFailed()
        {
            levelManager.LevelFailed();
            uiController.LevelFailed();
        }

        public void ReturnToMainMenu()
        {
            uiController.ReturnToMainMenu();
        }

        public void StartGame()
        {
            levelManager.StartGame();
            uiController.StartGame();
        }
    }
}
