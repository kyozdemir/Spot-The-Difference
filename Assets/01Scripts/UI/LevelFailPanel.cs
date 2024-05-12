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

        private void OnClickedButtonRetry()
        {
            GameManager.Instance.StartGame();
        }
        
        private void OnClickedButtonReturn()
        {
            GameManager.Instance.ReturnToMainMenu();
        }

        private void OnDestroy()
        {
            buttonRetry.onClick.RemoveListener(OnClickedButtonRetry);
            buttonReturn.onClick.RemoveListener(OnClickedButtonReturn);
        }
    }
}
