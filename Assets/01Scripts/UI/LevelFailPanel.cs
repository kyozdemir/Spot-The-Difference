using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpotTheDifference
{
    public class LevelFailPanel : UIPanel
    {
        [SerializeField] private Button buttonRetry;
        [SerializeField] private Button buttonReturn;

        public override void Initialize()
        {
            base.Initialize();
            buttonRetry.onClick.AddListener(OnClickedButtonRetry);
            buttonReturn.onClick.AddListener(OnClickedButtonReturn);
        }

        public override void ShowPanel()
        {
            base.ShowPanel();
            GameManager.Instance.soundManager.PlayGameStateSound(GameStateSound.LevelFail);
            Taptic.Failure();
        }

        private void OnClickedButtonRetry()
        {
            GameManager.Instance.StartGame();
            GameManager.Instance.soundManager.PlayClickSound(ClickSound.ButtonClick);
            Taptic.Light();
        }
        
        private void OnClickedButtonReturn()
        {
            Debug.Log("CLICKED");
            GameManager.Instance.ReturnToMainMenu();
            GameManager.Instance.soundManager.PlayClickSound(ClickSound.ButtonClick);
            Taptic.Light();
        }

        private void OnDestroy()
        {
            buttonRetry.onClick.RemoveListener(OnClickedButtonRetry);
            buttonReturn.onClick.RemoveListener(OnClickedButtonReturn);
        }
    }
}
