using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpotTheDifference
{
    public class LevelCompletePanel : UIPanel
    {
        [SerializeField] private Button buttonNext;
        [SerializeField] private Button buttonReturn;
        
        public override void Initialize()
        {
            base.Initialize();
            buttonNext.onClick.AddListener(OnClickedButtonNext);
            buttonReturn.onClick.AddListener(OnClickedButtonReturn);
        }

        public override void ShowPanel()
        {
            base.ShowPanel();
            GameManager.Instance.soundManager.PlayGameStateSound(GameStateSound.LevelComplete);
            Taptic.Success();
        }

        private void OnClickedButtonNext()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.soundManager.PlayClickSound(ClickSound.ButtonClick);
            Taptic.Light();
        }

        private void OnClickedButtonReturn()
        {
            GameManager.Instance.ReturnToMainMenu();
            GameManager.Instance.soundManager.PlayClickSound(ClickSound.ButtonClick);
            Taptic.Light();
        }

        private void OnDestroy()
        {
            buttonNext.onClick.RemoveListener(OnClickedButtonNext);
            buttonReturn.onClick.RemoveListener(OnClickedButtonReturn);
        }
    }
}
