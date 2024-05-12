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
        }

        public void LevelCompleted()
        {
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
