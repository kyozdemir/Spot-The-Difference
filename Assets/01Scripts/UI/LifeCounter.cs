using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpotTheDifference
{
    public class LifeCounter : MonoBehaviour, IBehaviour
    {
        [SerializeField] private TMP_Text lifeCounterText;
        private int _remainingHealth;
        
        public void Initialize()
        {
            GameManager.Instance.levelManager.OnObjectSelected += OnObjectSelected;
            _remainingHealth = Constants.Prefs.MAX_HEALTH_COUNT;
            UpdateLabels();
        }
        
        private void UpdateLabels()
        {
            lifeCounterText.SetText($"LIFE: {_remainingHealth}/{Constants.Prefs.MAX_HEALTH_COUNT}");
        }

        public void StartGame()
        {
            _remainingHealth = Constants.Prefs.MAX_HEALTH_COUNT;
            UpdateLabels();
        }

        #region Events

        private void OnObjectSelected(bool state)
        {
            if (!state)
            {
                _remainingHealth = Mathf.Clamp(--_remainingHealth,0,Constants.Prefs.MAX_HEALTH_COUNT);
                UpdateLabels();

                if (_remainingHealth == 0) GameManager.Instance.LevelFailed();
            }
        }

        private void OnDestroy()
        {
            if (GameManager.Instance is not null && GameManager.Instance.levelManager is not null)
            {
                GameManager.Instance.levelManager.OnObjectSelected -= OnObjectSelected;
            }
        }

        #endregion Events
    }
}
