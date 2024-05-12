using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpotTheDifference
{
    public class FoundObjectCounter : MonoBehaviour, IBehaviour
    {
        [SerializeField] private TMP_Text counterText;
        private int _foundObjectCount;
        private int _maxObjectCount;

        public void Initialize()
        {
            GameManager.Instance.levelManager.OnObjectSelected += OnObjectSelected;
        }

        private void NewObjectFound()
        {
            _foundObjectCount++;
            UpdateLabels();
        }
        
        private void UpdateLabels()
        {
            counterText.SetText($"FOUND: {_foundObjectCount}/{_maxObjectCount}");
        }
        
        public void StartGame()
        {
            _foundObjectCount = 0;
            _maxObjectCount = GameManager.Instance.levelManager.GetActivatedLevel().GetObjectCount();
            UpdateLabels();
        }

        #region Events

        private void OnObjectSelected(bool state)
        {
            if (state)
            {
                NewObjectFound();
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
