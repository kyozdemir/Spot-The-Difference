using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpotTheDifference
{
    public class MainMenuPanel : UIPanel
    {
        [SerializeField] private Button buttonPlay;
        
        public override void Initialize()
        {
            base.Initialize();
            buttonPlay.onClick.AddListener(OnClickedButtonPlay);
        }

        private void OnClickedButtonPlay()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.soundManager.PlayGameStateSound(GameStateSound.StartGame);
        }

        private void OnDestroy()
        {
            buttonPlay.onClick.RemoveListener(OnClickedButtonPlay);
        }
    }
}
