using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpotTheDifference
{
    public class LevelManager : MonoBehaviour, IBehaviour
    {
        //Storing level prefabs using such a list causes high RAM usage.
        //Normally, I avoid this method.
        //I prefer the methods such as resources or addressables,
        //but since there will be a single level in this project, these are not necessary.
        [Header("Level Prefabs")] [SerializeField]
        private List<LevelController> levels;

        [Header("Values")] [SerializeField] private int activatedLevelIndex;
        [SerializeField] private int currentLevelNumber;

        [Header("Component References")] [SerializeField]
        private Transform levelParentTransform;

        private LevelController _currentLevel;

        public event Action<bool> OnObjectSelected;

        public int CurrentLevelNumber => currentLevelNumber;

        public void Initialize()
        {
            //Normally, I load what level the player is by reading these values from the disk,
            //but there is no need for this in this demo project.
            activatedLevelIndex = 0;
            currentLevelNumber = 0;
        }

        private void DeactivateLevel()
        {
            if (_currentLevel is null) return;

            _currentLevel.OnDifferenceSelected -= OnDifferenceSelected;
            _currentLevel?.Deactivate();
        }

        public void ActivateCurrentLevel()
        {
            DeactivateLevel();

            activatedLevelIndex = GetLevelNumber();

            LevelController next = levels[activatedLevelIndex];

            LevelController nextLevel = Instantiate(next, levelParentTransform);
            if (_currentLevel is not null)
            {
                DestroyImmediate(_currentLevel.gameObject);
                _currentLevel = null;
            }

            _currentLevel = nextLevel.GetComponent<LevelController>();
            _currentLevel.Initialize();
            _currentLevel.Activate();
            _currentLevel.OnDifferenceSelected += OnDifferenceSelected;
        }

        public LevelController GetActivatedLevel() => _currentLevel;

        private int GetLevelNumber()
        {
            if (IsRandomLevelSelectionAvaliable())
            {
                int recurringLevelIndex = activatedLevelIndex;
                if (levels.Count > 1)
                {
                    do
                    {
                        recurringLevelIndex = Random.Range(0, levels.Count);
                    } while (recurringLevelIndex == activatedLevelIndex);
                }

                return recurringLevelIndex;
            }

            return currentLevelNumber;
        }

        public bool IsRandomLevelSelectionAvaliable() => levels.Count - 1 < currentLevelNumber;

        #region Events

        private void OnDifferenceSelected(bool state)
        {
            OnObjectSelected?.Invoke(state);
        }

        #endregion Events

        #region Game State Methods

        public void LevelCompleted()
        {
            currentLevelNumber++;
        }

        public void LevelFailed()
        {
        }

        public void ReturnedToMainMenu()
        {
            DeactivateLevel();
        }

        public void StartGame()
        {
            ActivateCurrentLevel();
        }

        #endregion
    }
}